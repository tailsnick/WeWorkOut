using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeWorkOut.Models;
using WeWorkOut.Data;
using Microsoft.AspNetCore.Authorization;

namespace WeWorkOut.Controllers
{
    [Authorize]
    public class GoalsController : Controller
    {
        private readonly DB _context;

        public GoalsController(DB context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<JsonResult> DeleteConfirmed(int id)
        {
            var goal = await _context.Goal.FindAsync(id);
            _context.Goal.Remove(goal);
            await _context.SaveChangesAsync();
            return Json(new
            {
                success = true
            });
        }

        // GET: Goals
        public async Task<IActionResult> Index()
        {
            // The exercise options that will be availble for creating a new goal
            ViewData["ExerciseOptions"] = await _context.Exercise.ToListAsync();

            // Extract the user's ID.
            string userID = User.Claims.First().Value;

            // Get the goals associated with that user
            List<Goal> goals = await _context.Goal
                .FromSqlInterpolated($"SELECT * FROM Goal WHERE UserID={userID}")
                .Include(g => g.Exercise)
                .ToListAsync();
            
            return View(goals);
        }


        //// POST: Goals/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("GoalID,ExerciseID,TargetMeasurementQuantity,TargetMeasurementUnits,Deadline,Completed")] Goal goal)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(goal);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ExerciseID"] = new SelectList(_context.Exercise, "ExerciseID", "ExerciseID", goal.ExerciseID);
        //    return View(goal);
        //}

        [HttpPost]
        public async Task<JsonResult> CreateNewGoal(string exercise, double quantity, string unitsType, DateTime? completionDate)
        {
            Exercise e = await _context.Exercise
                .FromSqlInterpolated($"SELECT * FROM Exercise WHERE Name={exercise}")
                .FirstOrDefaultAsync();

            // If the user doesn't provide a deadline, make the completion date null.
            //   Otherwise, the DateTime class will automatically parse "" into January 1, 2001
            if (completionDate.Equals(""))
            {
                completionDate = null;
            }
            
            Goal g = new Goal()
            {
                Exercise = e,
                ExerciseID = e.ExerciseID,
                MeasurementQuantity = quantity,
                MeasurementType = unitsType,
                UserID = User.Claims.First().Value,
                Deadline = completionDate
            };

            _context.Add(g);
            await _context.SaveChangesAsync();

            return Json(new
            {
                success = false
            });
        }
        
        [HttpPost]
        public async Task<JsonResult> EditGoal(int id, double newQuantity, DateTime newDeadline)
        { 
            Goal goal = await _context.Goal
                .Include(g => g.Exercise)
                .FirstOrDefaultAsync(m => m.GoalID == id);
            
            goal.MeasurementQuantity = newQuantity;
            goal.Deadline = newDeadline;

            _context.Update(goal);
            await _context.SaveChangesAsync();

            return Json(new
            {
                success = false
            });
        }

    }
}

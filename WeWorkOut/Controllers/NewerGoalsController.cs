using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeWorkOut.Data;
using WeWorkOut.Models;

namespace WeWorkOut.Controllers
{
    public class NewerGoalsController : Controller
    {
        private readonly DB _context;

        public NewerGoalsController(DB context)
        {
            _context = context;
        }

        // GET: NewerGoals
        public async Task<IActionResult> Index()
        {
            var dB = _context.Goal.Include(g => g.Exercise);
            return View(await dB.ToListAsync());
        }

        // GET: NewerGoals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goal = await _context.Goal
                .Include(g => g.Exercise)
                .FirstOrDefaultAsync(m => m.GoalID == id);
            if (goal == null)
            {
                return NotFound();
            }

            return View(goal);
        }

        // GET: NewerGoals/Create
        public IActionResult Create()
        {
            ViewData["ExerciseID"] = new SelectList(_context.Exercise, "ExerciseID", "ExerciseID");
            return View();
        }

        // POST: NewerGoals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GoalID,ExerciseID,UserID,MeasurementQuantity,MeasurementType,Deadline,Completed")] Goal goal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExerciseID"] = new SelectList(_context.Exercise, "ExerciseID", "ExerciseID", goal.ExerciseID);
            return View(goal);
        }

        // GET: NewerGoals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goal = await _context.Goal.FindAsync(id);
            if (goal == null)
            {
                return NotFound();
            }
            ViewData["ExerciseID"] = new SelectList(_context.Exercise, "ExerciseID", "ExerciseID", goal.ExerciseID);
            return View(goal);
        }

        // POST: NewerGoals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("GoalID,ExerciseID,UserID,MeasurementQuantity,MeasurementType,Deadline,Completed")] Goal goal)
        {
            if (id != goal.GoalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoalExists(goal.GoalID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExerciseID"] = new SelectList(_context.Exercise, "ExerciseID", "ExerciseID", goal.ExerciseID);
            return View(goal);
        }

        // GET: NewerGoals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goal = await _context.Goal
                .Include(g => g.Exercise)
                .FirstOrDefaultAsync(m => m.GoalID == id);
            if (goal == null)
            {
                return NotFound();
            }

            return View(goal);
        }

        // POST: NewerGoals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var goal = await _context.Goal.FindAsync(id);
            _context.Goal.Remove(goal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoalExists(int? id)
        {
            return _context.Goal.Any(e => e.GoalID == id);
        }
    }
}

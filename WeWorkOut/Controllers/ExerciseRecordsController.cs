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
    public class ExerciseRecordsController : Controller
    {
        private readonly DB _context;

        public ExerciseRecordsController(DB context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<JsonResult> DeleteConfirmed(int id)
        {
            var exerciseRecord = await _context.ExerciseRecord.FindAsync(id);
            _context.ExerciseRecord.Remove(exerciseRecord);
            await _context.SaveChangesAsync();
            return Json(new
            {
                success = true
            });
        }

        // GET: ExerciseRecords
        public async Task<IActionResult> Index()
        {
            // The exercise options that will be availble for creating a new goal
            ViewData["ExerciseOptions"] = await _context.Exercise.ToListAsync();

            // Extract the user's ID.
            string userID = User.Claims.First().Value;

            // Get the exercise records associated with that user
            List<ExerciseRecord> records = await _context.ExerciseRecord
                .FromSqlInterpolated($"SELECT * FROM ExerciseRecord WHERE UserID={userID}")
                .Include(er => er.Exercise)
                .ToListAsync();

            return View(records);
        }

        [HttpPost]
        public async Task<JsonResult> CreateNewExerciseRecord(string exercise, double? weightQuantity, double? distanceQuantity, double? timeQuantity, double? repsQuantity, DateTime submitDate)
        {
            Exercise e = await _context.Exercise
                .FromSqlInterpolated($"SELECT * FROM Exercise WHERE Name={exercise}")
                .FirstOrDefaultAsync();

            ExerciseRecord er = new ExerciseRecord() {
                Exercise = e,
                ExcerciseID = e.ExerciseID,
                UserID = User.Claims.First().Value,
                WeightQuantity = weightQuantity,
                DistanceQuantity = distanceQuantity,
                TimeQuantity = timeQuantity,
                RepQuantity = repsQuantity,
                SubmitDate = submitDate
            };

            _context.Add(er);
            await _context.SaveChangesAsync();

            return Json(new
            {
                success = false
            });
        }

    }
}

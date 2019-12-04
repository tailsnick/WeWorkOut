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
    public class ProgressController : Controller
    {
        private readonly DB _context;

        public ProgressController(DB context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // The exercise options that will be availble for creating a new goal
            ViewData["ExerciseOptions"] = await _context.Exercise.ToListAsync();

            

            // Extract the user's ID.
            string userID = User.Claims.First().Value;

            List<Goal> userGoals = await _context.Goal
                .FromSqlInterpolated($"SELECT * FROM Goal WHERE UserID={userID}") //ORDER BY ExerciseID
                .ToListAsync();

            return View(userGoals);
        }

        //Get data for that exercise, from the user, and sends it back to the javascript
        public async Task<JsonResult> GetSubmittedData(int exerciseID, string goalType)
        {
            // DB Query to get goal from DB

            // Examine the goal, identify the exercise

            // Examine the goal, identify the measurement type (time, reps, weight, etc.)

            // Query the Exercise record DB.  Using:  Exercise = exercise, userid = userid, where measurement type (for that goal) != null

            // LIst<DateTime> x = new LIst<DAteTime
            // List<int> y = new Ist<int>

            // for each thing in ExerciseREcords
            // x.add(er.datetime)

            //////////////PLACE HOLDER CODE!!!!!!!//////////
            List<ExerciseRecord> records = new List<ExerciseRecord>();

            // Extract the user's ID.
            string userID = User.Claims.First().Value;

            // Get the exercise records associated with that user, that exerciseID and that specific column being not null
            switch (goalType) 
            {
                case "Time":
                    records = await _context.ExerciseRecord
                        .FromSqlInterpolated($"SELECT * FROM ExerciseRecord WHERE ExcerciseID={exerciseID} AND UserID={userID} AND TimeQuantity IS NOT NULL")
                        .Include(er => er.Exercise)
                        .ToListAsync();
                    break;
                case "Weight":
                    records = await _context.ExerciseRecord
                        .FromSqlInterpolated($"SELECT * FROM ExerciseRecord WHERE ExcerciseID={exerciseID} AND UserID={userID} AND WeightQuantity IS NOT NULL")
                        .Include(er => er.Exercise)
                        .ToListAsync();
                    break;
                case "Reps":
                    records = await _context.ExerciseRecord
                        .FromSqlInterpolated($"SELECT * FROM ExerciseRecord WHERE ExcerciseID={exerciseID} AND UserID={userID} AND RepQuantity IS NOT NULL")
                        .Include(er => er.Exercise)
                        .ToListAsync();
                    break;
                case "Distance":
                    records = await _context.ExerciseRecord
                        .FromSqlInterpolated($"SELECT * FROM ExerciseRecord WHERE ExcerciseID={exerciseID} AND UserID={userID} AND DistanceQuantity IS NOT NULL")
                        .Include(er => er.Exercise)
                        .ToListAsync();
                    break;
            }

            
            

            if (records != null)
            {
                return Json(new
                {
                    success = true,
                    
                }); ;
            }
            else
            {
                return Json(new
                {
                    success = false
                });
            }

            //////////////////////////////////////////////////
        }
    }
}
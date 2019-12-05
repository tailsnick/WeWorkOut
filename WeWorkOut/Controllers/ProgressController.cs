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
        [HttpPost]
        public async Task<JsonResult> GetSubmittedData(int exerciseID, string measurementType)
        {
            // Extract the user's ID.
            string userID = User.Claims.First().Value;

            // Get the exercise records associated with that user, that exerciseID and that specific column being not null
            string quantityName = "";
            switch (measurementType)
            {
                case "Distance":
                    quantityName = "DistanceQuantity";
                    break;
                case "Time":
                    quantityName = "TimeQuantity";
                    break;
                case "Weight":
                    quantityName = "WeightQuantity";
                    break;
                case "Reps":
                    quantityName = "RepQuantity";
                    break;
            }

            List<ExerciseRecord> records = await _context.ExerciseRecord
                .FromSqlInterpolated($"SELECT * FROM ExerciseRecord WHERE ExerciseID={exerciseID} AND UserID={userID} AND {quantityName} IS NOT NULL") 
                .OrderBy(o=>o.SubmitDate)
                .ToListAsync();




            JsonResult test = Json(new {
                data = records.Select(record => new
                {
                    x = record.SubmitDate,
                    y = record.TimeQuantity
                })});





            return test;



            //if (records != null)
            //{
            //    return Json(new
            //    {
            //        success = true,

            //    }); ;
            //}
            //else
            //{
            //    return Json(new
            //    {
            //        success = false
            //    });
            //}
        }
    }
}
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
using System.Web;

namespace WeWorkOut.Controllers
{
    [Authorize]
    public class ExercisesController : Controller
    {
        private readonly DB _context;

        public ExercisesController(DB context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Exercise.ToListAsync());
        }

        // Determine the validity for all units for a given exercise.
        [HttpPost]
        public async Task<JsonResult> GetValidUnits(string exerciseName)
        {
            Exercise e = await _context.Exercise
                .FromSqlInterpolated($"SELECT * FROM Exercise WHERE Name={exerciseName}")
                .FirstOrDefaultAsync();

            if (e != null)
            {
                return Json(new
                {
                    success = true,
                    weightValid = e.WeightMeasurementsValid,
                    distanceValid = e.DistanceMeasurementsValid,
                    timeValid = e.TimeMeasurementsValid,
                    repsValid = e.RepMeasurementsValid
                }); ;
            }
            else
            {
                return Json(new
                {
                    success = false
                });
            }
        }

        // Get HTML guide for the description of the exerciseName
        [HttpPost]
        public async Task<JsonResult> GetGuide(string exerciseName)
        {
            Exercise e = await _context.Exercise
                .FromSqlInterpolated($"SELECT * FROM Exercise WHERE Name={exerciseName}")
                .FirstOrDefaultAsync();

            //encoded
            string desc = e.HTMLDescription;

            //decoded
            desc = HttpUtility.HtmlDecode(desc);

            return Json(new
            {
                success = true,
                htmlDesc = desc
            });
        }
    }
}

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


        // GET: Exercises
        public async Task<IActionResult> Index()
        {            
            return View(await _context.Exercise.ToListAsync());
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

        // GET: Exercises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _context.Exercise
                .FirstOrDefaultAsync(m => m.ExerciseID == id);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

        // GET: Exercises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Exercises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExerciseID,Name")] Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exercise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exercise);
        }

        // GET: Exercises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _context.Exercise.FindAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }
            return View(exercise);
        }

        // POST: Exercises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExerciseID,Name")] Exercise exercise)
        {
            if (id != exercise.ExerciseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exercise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExerciseExists((int)exercise.ExerciseID))
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
            return View(exercise);
        }

        // GET: Exercises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _context.Exercise
                .FirstOrDefaultAsync(m => m.ExerciseID == id);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

        // POST: Exercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exercise = await _context.Exercise.FindAsync(id);
            _context.Exercise.Remove(exercise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExerciseExists(int id)
        {
            return _context.Exercise.Any(e => e.ExerciseID == id);
        }
    }
}

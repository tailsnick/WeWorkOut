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

            // Get the goals associated with that user
            ViewData["UserGoals"] = await _context.Goal
                .FromSqlInterpolated($"SELECT * FROM Goal WHERE UserID={userID}")
                .Include(g => g.Exercise)
                .ToListAsync();

            // Get the exercise records associated with that user
            ViewData["UserRecords"] = await _context.ExerciseRecord
                .FromSqlInterpolated($"SELECT * FROM ExerciseRecord WHERE UserID={userID}")
                .Include(er => er.Exercise)
                .ToListAsync();

            return View();
        }
    }
}
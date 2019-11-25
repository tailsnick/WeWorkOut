using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeWorkOut.Areas.Identity;
using WeWorkOut.Data;
using WeWorkOut.Models;

namespace WeWorkOut.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly DB _context;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            DB context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required]
            [Display(Name = "Use Metric Units")]
            public bool UseMetricUnits { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                UseMetricUnits = user.UseMetricUnits
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }

            if (Input.UseMetricUnits != user.UseMetricUnits)
            {
                user.UseMetricUnits = Input.UseMetricUnits;

                // TODO:  Convert to/from metric/imperial units here.
                
                // Extract the user's ID.
                string userID = User.Claims.First().Value;

                // Get the goals associated with that user
                List<Goal> goals = await _context.Goal
                    .FromSqlInterpolated($"SELECT * FROM Goal WHERE UserID={userID}")
                    .Include(g => g.Exercise)
                    .ToListAsync();

                // Convert all goals from metric to imperial
                foreach (Goal g in goals)
                {
                    if(g.MeasurementType.Equals("Weight"))
                    {
                        if (user.UseMetricUnits)
                        {
                            // Convert from imperial to metric (1 lb = 0.45359 kg).
                            g.MeasurementQuantity *= 0.45359;   // Multiply instead of divide to avoid dividing by zero
                        }
                        else
                        {
                            // Convert from metric to imperial (1 kg = 2.2046 lbs)
                            g.MeasurementQuantity *= 2.2046;  // Multiply instead of divide to avoid dividing by zero
                        }
                        _context.Update(g);
                        await _context.SaveChangesAsync();
                    }
                    else if(g.MeasurementType.Equals("Distance"))
                    {
                        if (user.UseMetricUnits)
                        {
                            // Convert from imperial to metric (1 mi = 1.6093 km).
                            g.MeasurementQuantity *= 1.6093;   // Multiply instead of divide to avoid dividing by zero
                        }
                        else
                        {
                            // Convert from metric to imperial (1 km = 0.62137 mi)
                            g.MeasurementQuantity *= 0.62137;  // Multiply instead of divide to avoid dividing by zero
                        }
                        _context.Update(g);
                        await _context.SaveChangesAsync();
                    }
                }


                // Get the exercise records associated with that user
                List<ExerciseRecord> exerciseRecords = await _context.ExerciseRecord
                    .FromSqlInterpolated($"SELECT * FROM ExerciseRecord WHERE UserID={userID}")
                    .Include(g => g.Exercise)
                    .ToListAsync();

                // Convert all goals from metric to imperial
                foreach (ExerciseRecord er in exerciseRecords)
                {
                    if (er.WeightQuantity != null)
                    {
                        if (user.UseMetricUnits)
                        {
                            // Convert from imperial to metric (1 lb = 0.45359 kg).
                            er.WeightQuantity *= 0.45359;   // Multiply instead of divide to avoid dividing by zero
                        }
                        else
                        {
                            // Convert from metric to imperial (1 kg = 2.2046 lbs)
                            er.WeightQuantity *= 2.2046;  // Multiply instead of divide to avoid dividing by zero
                        }
                    }
                    if (er.DistanceQuantity != null)
                    {
                        if (user.UseMetricUnits)
                        {
                            // Convert from imperial to metric (1 mi = 1.6093 km).
                            er.DistanceQuantity *= 1.6093;   // Multiply instead of divide to avoid dividing by zero
                        }
                        else
                        {
                            // Convert from metric to imperial (1 km = 0.62137 mi)
                            er.DistanceQuantity *= 0.62137;  // Multiply instead of divide to avoid dividing by zero
                        }
                    }

                    // Save the changeds
                    _context.Update(er);
                    await _context.SaveChangesAsync();
                }
            }

        await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}

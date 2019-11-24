using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeWorkOut.Areas.Identity;

namespace WeWorkOut.Data
{
    public static class UsersRolesDBInitializer
    {
        public static async Task InitializeAsync(UsersRolesDB context,
       IServiceProvider serviceProvider)
        {
            context.Database.Migrate();

            if (!context.Users.Any())
            {
                string plainTextPassword = "aA123!@#";  // TODO:  Use user secrets to hide this password

                var userManager = serviceProvider
                    .GetRequiredService<UserManager<ApplicationUser>>();

                var user1 = new ApplicationUser { Id="1", UserName = "Jane_Doe@example.com", Email = "Jane_Doe@example.com", EmailConfirmed = true, UseMetricUnits=false };
                var user2 = new ApplicationUser { Id="2", UserName = "John_Doe@example.com", Email = "John_Doe@example.com", EmailConfirmed = true, UseMetricUnits=true };

                await userManager.CreateAsync(user1, plainTextPassword);
                await userManager.CreateAsync(user2, plainTextPassword);
            }

            await context.SaveChangesAsync();
        }
    }
}

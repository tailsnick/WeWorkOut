using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                    .GetRequiredService<UserManager<IdentityUser>>();

                var user1 = new IdentityUser { Id="1", UserName = "Jane_Doe@example.com", Email = "Jane_Doe@example.com", EmailConfirmed = true };
                var user2 = new IdentityUser { Id="2", UserName = "John_Doe@example.com", Email = "John_Doe@example.com", EmailConfirmed = true };

                await userManager.CreateAsync(user1, plainTextPassword);
                await userManager.CreateAsync(user2, plainTextPassword);
            }

            await context.SaveChangesAsync();
        }
    }
}

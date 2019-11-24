using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WeWorkOut.Data;

namespace WeWorkOut
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // CreateHostBuilder(args).Build().Run();

            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    // Seed some exercises, goals, and exercise records
                    var context = services.GetRequiredService<DB>();
                    DBInitializer.Initialize(context);

                    // Seed the users DB
                    var usersContext = services.GetRequiredService<UsersRolesDB>();
                    UsersRolesDBInitializer.InitializeAsync(usersContext, services).Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                    throw (ex); // Throw the exception, so we will be alerted if/when there's a problem seeding.
                }
            }

            host.Run();




        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

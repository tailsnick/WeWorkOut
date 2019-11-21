using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeWorkOut.Models;

namespace WeWorkOut.Data
{
    public class DBInitializer
    {
        public static void Initialize(DB context)
        {
            context.Database.Migrate();

            // Look for any courses.
            if (context.Exercise.Any())
            {
                return;   // DB has been seeded
            }

            // Seed some exercises.  
            //var exercises = new Exercise[]
            //{
            //    new Exercise{Name = "Running"},

            //};

            //foreach (Course cm in exercises)
            //{
            //    context.Courses.Add(cm);
            //}

            //context.SaveChanges();



        }




    }
}

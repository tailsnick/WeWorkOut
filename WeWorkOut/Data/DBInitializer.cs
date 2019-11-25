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
            Exercise running = new Exercise { Name = "Running",  DistanceMeasurementsValid = true,  TimeMeasurementsValid = true,  RepMeasurementsValid = false, WeightMeasurementsValid = false };
            Exercise squats  = new Exercise { Name = "Squats",   DistanceMeasurementsValid = false, TimeMeasurementsValid = false, RepMeasurementsValid = true,  WeightMeasurementsValid = true };
            Exercise pushups = new Exercise { Name = "Push-ups", DistanceMeasurementsValid = false, TimeMeasurementsValid = false, RepMeasurementsValid = true,  WeightMeasurementsValid = false };
            
            var exercises = new Exercise[] { running, squats, pushups };

            foreach (Exercise ex in exercises)
            {
                context.Exercise.Add(ex);
            }

            context.SaveChanges();

            // Seed some goals.  
            var goals = new Goal[]
            {
                new Goal{UserID="1", Exercise = running, MeasurementType="Time",     MeasurementQuantity=30, Completed=false, Deadline=new DateTime(2019, 12, 25)},
                new Goal{UserID="1", Exercise = running, MeasurementType="Distance", MeasurementQuantity=2,  Completed=false, Deadline=new DateTime(2020,  1,  1)},
                new Goal{UserID="1", Exercise = pushups, MeasurementType="Time",     MeasurementQuantity=30, Completed=true,  Deadline=new DateTime(2019, 11, 15)},
                new Goal{UserID="1", Exercise = pushups, MeasurementType="Reps",     MeasurementQuantity=50, Completed=false, Deadline=new DateTime(2019, 11,  3)}
            };

            foreach (Goal g in goals)
            {
                context.Goal.Add(g);
            }

            context.SaveChanges();

            // Seed some exercise records.  
            var records = new ExerciseRecord[]
            {
                new ExerciseRecord{UserID="1", Exercise=running, SubmitDate=DateTime.Parse("2019/11/11 15:00:00"), DistanceQuantity=0.5, TimeQuantity=9},
                new ExerciseRecord{UserID="1", Exercise=running, SubmitDate=DateTime.Parse("2019/11/12 15:00:00"), DistanceQuantity=0.5, TimeQuantity=9},
                new ExerciseRecord{UserID="1", Exercise=running, SubmitDate=DateTime.Parse("2019/11/13 15:00:00"), DistanceQuantity=0.5, TimeQuantity=8},
                new ExerciseRecord{UserID="1", Exercise=running, SubmitDate=DateTime.Parse("2019/11/14 15:00:00"), DistanceQuantity=1,   TimeQuantity=17},
                new ExerciseRecord{UserID="1", Exercise=running, SubmitDate=DateTime.Parse("2019/11/15 15:00:00"), DistanceQuantity=1,   TimeQuantity=16},
                new ExerciseRecord{UserID="1", Exercise=running, SubmitDate=DateTime.Parse("2019/11/16 15:00:00"), DistanceQuantity=1,   TimeQuantity=18},
                new ExerciseRecord{UserID="1", Exercise=running, SubmitDate=DateTime.Parse("2019/11/17 15:00:00"), DistanceQuantity=1.5, TimeQuantity=24},

                new ExerciseRecord{UserID="1", Exercise=pushups, SubmitDate=DateTime.Parse("2019/11/11 15:15:00"), RepQuantity=20},
                new ExerciseRecord{UserID="1", Exercise=pushups, SubmitDate=DateTime.Parse("2019/11/12 15:15:00"), RepQuantity=25},
                new ExerciseRecord{UserID="1", Exercise=pushups, SubmitDate=DateTime.Parse("2019/11/13 15:15:00"), RepQuantity=25},
                new ExerciseRecord{UserID="1", Exercise=pushups, SubmitDate=DateTime.Parse("2019/11/14 15:15:00"), RepQuantity=30},
                new ExerciseRecord{UserID="1", Exercise=pushups, SubmitDate=DateTime.Parse("2019/11/15 15:15:00"), RepQuantity=30},
                new ExerciseRecord{UserID="1", Exercise=pushups, SubmitDate=DateTime.Parse("2019/11/16 15:15:00"), RepQuantity=40},
                new ExerciseRecord{UserID="1", Exercise=pushups, SubmitDate=DateTime.Parse("2019/11/17 15:15:00"), RepQuantity=35}
            };

            foreach (ExerciseRecord er in records)
            {
                context.ExerciseRecord.Add(er);
            }

            context.SaveChanges();

        }




    }
}

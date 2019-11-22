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
            Exercise running = new Exercise { Name = "Running",  AcceptsDistanceMeasurements = true,  AcceptsTimeMeasurements = true,  AcceptsRepMeasurements = false, AcceptsWeightMeasurements = false };
            Exercise squats  = new Exercise { Name = "Squats",   AcceptsDistanceMeasurements = false, AcceptsTimeMeasurements = false, AcceptsRepMeasurements = true,  AcceptsWeightMeasurements = true };
            Exercise pushups = new Exercise { Name = "Push-ups", AcceptsDistanceMeasurements = false, AcceptsTimeMeasurements = false, AcceptsRepMeasurements = true,  AcceptsWeightMeasurements = false };
            
            var exercises = new Exercise[] { running, squats, pushups };

            foreach (Exercise ex in exercises)
            {
                context.Exercise.Add(ex);
            }

            context.SaveChanges();

            // Seed some goals.  
            var goals = new Goal[]
            {
                new Goal{Exercise = running, TargetMeasurementUnits="minutes", TargetMeasurementQuantity=20, Completed=false, Deadline=new DateTime(2019, 12, 25) },
                new Goal{Exercise = running, TargetMeasurementUnits="miles",   TargetMeasurementQuantity=2,  Completed=false, Deadline=new DateTime(2020,  1,  1) },
                new Goal{Exercise = pushups, TargetMeasurementUnits="reps",    TargetMeasurementQuantity=50, Completed=true,  Deadline=new DateTime(2019, 11,  3) }
            };

            foreach (Goal g in goals)
            {
                context.Goal.Add(g);
            }

            context.SaveChanges();

            // Seed some exercise records.  
            var records = new ExerciseRecord[]
            {
                new ExerciseRecord{Exercise=running, SubmitDate=DateTime.Parse("2019/11/11 15:00:00"), DistanceQuantity=0.5, DistanceUnits="miles", TimeQuantity=9,  TimeUnits="minutes"},
                new ExerciseRecord{Exercise=running, SubmitDate=DateTime.Parse("2019/11/12 15:00:00"), DistanceQuantity=0.5, DistanceUnits="miles", TimeQuantity=9,  TimeUnits="minutes"},
                new ExerciseRecord{Exercise=running, SubmitDate=DateTime.Parse("2019/11/13 15:00:00"), DistanceQuantity=0.5, DistanceUnits="miles", TimeQuantity=8,  TimeUnits="minutes"},
                new ExerciseRecord{Exercise=running, SubmitDate=DateTime.Parse("2019/11/14 15:00:00"), DistanceQuantity=1,   DistanceUnits="miles", TimeQuantity=17, TimeUnits="minutes"},
                new ExerciseRecord{Exercise=running, SubmitDate=DateTime.Parse("2019/11/15 15:00:00"), DistanceQuantity=1,   DistanceUnits="miles", TimeQuantity=16, TimeUnits="minutes"},
                new ExerciseRecord{Exercise=running, SubmitDate=DateTime.Parse("2019/11/16 15:00:00"), DistanceQuantity=1,   DistanceUnits="miles", TimeQuantity=18, TimeUnits="minutes"},
                new ExerciseRecord{Exercise=running, SubmitDate=DateTime.Parse("2019/11/17 15:00:00"), DistanceQuantity=1.5, DistanceUnits="miles", TimeQuantity=24, TimeUnits="minutes"},

                new ExerciseRecord{Exercise=pushups, SubmitDate=DateTime.Parse("2019/11/11 15:15:00"), RepQuantity=20, RepUnits="Push-ups"},
                new ExerciseRecord{Exercise=pushups, SubmitDate=DateTime.Parse("2019/11/12 15:15:00"), RepQuantity=25, RepUnits="Push-ups"},
                new ExerciseRecord{Exercise=pushups, SubmitDate=DateTime.Parse("2019/11/13 15:15:00"), RepQuantity=25, RepUnits="Push-ups"},
                new ExerciseRecord{Exercise=pushups, SubmitDate=DateTime.Parse("2019/11/14 15:15:00"), RepQuantity=30, RepUnits="Push-ups"},
                new ExerciseRecord{Exercise=pushups, SubmitDate=DateTime.Parse("2019/11/15 15:15:00"), RepQuantity=30, RepUnits="Push-ups"},
                new ExerciseRecord{Exercise=pushups, SubmitDate=DateTime.Parse("2019/11/16 15:15:00"), RepQuantity=40, RepUnits="Push-ups"},
                new ExerciseRecord{Exercise=pushups, SubmitDate=DateTime.Parse("2019/11/17 15:15:00"), RepQuantity=35, RepUnits="Push-ups"}
            };

            foreach (ExerciseRecord er in records)
            {
                context.ExerciseRecord.Add(er);
            }

            context.SaveChanges();

        }




    }
}

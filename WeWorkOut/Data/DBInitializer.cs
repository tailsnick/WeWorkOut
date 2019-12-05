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

            string pushupHTML = "&lt;img src=&quot;image/push_up_1.jpg&quot; /&gt;    &lt;h1&gt;1) Get down on the ground.&lt;/h1&gt;    &lt;p&gt;        Lay with your toes on the ground holding yourself up with your hands.        Lower your torso to the ground until your elbows reach a 90-degree angle.        Keep your elbows close to your body for more resistance.        Keep your head facing forward.        Try to have the tip of your nose pointed directly ahead.        Keep your body in a flat plank—do not drop your hips, and do not have your butt hanging in the air.        It is important to keep your body as straight as possible.        Remember to breathe as you lower yourself.        -When doing push-ups, your chest should come within inches of the ground each time you go down for a rep.        Remember to keep your body at a flat level.    &lt;/p&gt;    &lt;img src=&quot;image/push_up_2.jpg&quot; /&gt;    &lt;h1&gt;2) Raise yourself by pushing the ground away from you.&lt;/h1&gt;    &lt;p&gt;        Breathe out as you push.        The power for that push will come from your shoulders and chest working in unison.        The triceps (the muscle on the back side of your upper arm) are also contracted but they aren&#39;t the primary muscle group being used.        Don&#39;t be tempted to use your rear end or your stomach.        Continue to exert force until your arms are almost in a straight position again, make sure to not lock your arms.    &lt;/p&gt;    &lt;img src=&quot;image/push_up_3.jpg&quot; /&gt;    &lt;h1&gt;3) Repeat lowering and raising at a steady pace.&lt;/h1&gt;    &lt;p&gt;        Each pair counts as a single push up.        Do this until you finish your set or you hit your maximum.    &lt;/p&gt;";

            // Seed some exercises. 
            Exercise running = new Exercise { Name = "Running",  DistanceMeasurementsValid = true,  TimeMeasurementsValid = true,  RepMeasurementsValid = false, WeightMeasurementsValid = false, HTMLDescription = "PLACE HOLDER" };
            Exercise squats  = new Exercise { Name = "Squats",   DistanceMeasurementsValid = false, TimeMeasurementsValid = false, RepMeasurementsValid = true,  WeightMeasurementsValid = true, HTMLDescription = "PLACE HOLDER" };
            Exercise pushups = new Exercise { Name = "Push-ups", DistanceMeasurementsValid = false, TimeMeasurementsValid = false, RepMeasurementsValid = true,  WeightMeasurementsValid = false, HTMLDescription = pushupHTML };
            
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
                new Goal{UserID="1", Exercise = squats, MeasurementType="Reps",     MeasurementQuantity=7, Completed=false},
                new Goal{UserID="1", Exercise = pushups, MeasurementType="Reps",     MeasurementQuantity=50, Completed=false, Deadline=new DateTime(2019, 11,  21)}
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

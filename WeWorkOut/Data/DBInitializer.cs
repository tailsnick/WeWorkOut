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
            string runningHTML = "&lt;img src=&quot;image/Running_1.png&quot; /&gt;    &lt;h1&gt;1) Start small.&lt;/h1&gt;    &lt;p&gt;        Before you start running every day, you should establish a base level of fitness.        Running is great for you, but it is physically punishing, and it can wreak havoc upon your body if you aren&#39;t ready.        If you start running with no prior exercise habits, you risk hurting yourself before you get into the swing of a routine.        Consider starting with daily walks and progressing gradually into running.        Consider hiking, swimming, or dancing--anything that gets you out the door and moving, regularly.    &lt;/p&gt;    &lt;img src=&quot;image/Running_2.png&quot; /&gt;    &lt;h1&gt;2) Warm up for five to ten minutes before each run.&lt;/h1&gt;    &lt;p&gt;        You should always do this--but it is especially crucial when you&#39;re first starting out, as your muscles are unused to the stress of running.        Try dynamic stretches.        Traditional, static stretches (touch your toes and hold the pose) are most effective when they follow a period of activity.        Save the static stretches for after you run.        Dynamic stretches may include lunges, squats, high-knees, and deadlifts.        The key here is to limber up and get your muscles working before you settle into a heavy run.    &lt;/p&gt;    &lt;img src=&quot;image/Running_3.png&quot; /&gt;    &lt;h1&gt;3) Breathe deep, steady breaths.&lt;/h1&gt;    &lt;p&gt;        Running is a highly aerobic exercise, and you will need to keep a constant flow of oxygen cycling through your body.        Focus on each breath: in... out... in... out...        Breathe in through your nose and out through your mouth.        Nose-breathing is much more efficient than mouth-breathing, and you will find that you do not become so out-of-breath when you are taking measured breaths through your nose.        Breathe from your belly, not from your chest. Make a conscious effort to fill up your stomach with deep breaths. You&#39;ll be able to absorb more oxygen this way, and your muscles will be able to carry you further before they tire.    &lt;/p&gt;    &lt;img src=&quot;image/Running_4.png&quot; /&gt;    &lt;h1&gt;4) Be aware of your running form.&lt;/h1&gt;    &lt;p&gt;        Everyone&#39;s body is unique, and every runner has a slightly different gait.         Start running and work out what feels right for you.                Pump your arms in compact swings. Keep them from swinging out of control, but do not tense them up.        Stand upright with a slight forward lean. Keep your back straight.        Pick your feet up high so that you don&#39;t trip over anything; but do not bounce off of the ground, as this transfers more force between your body and the ground.         Try to land softly in order to reduce stress on your knees, ankles, and feet.    &lt;/p&gt;    &lt;img src=&quot;image/Running_5.png&quot; /&gt;    &lt;h1&gt;5) Take comfortable strides.&lt;/h1&gt;    &lt;p&gt;        When you begin to run, you will notice that you fall into a natural stride length.         This may vary between sprinting, jogging, and running long-distance.        Notice your foot strike.         When you run in place, you should land on the balls of your feet.         This is how you were naturally supposed to run, so when you check your form, you want to either land on the balls of your foot or the middle.        In general, however: when you run faster, your foot will strike the ground further forward toward the toe.         If you are regularly heel-striking, your strides may be too long.    &lt;/p&gt;    &lt;img src=&quot;image/Running_6.png&quot; /&gt;    &lt;h1&gt;6) Relax your upper body, but hold your back straight.&lt;/h1&gt;    &lt;p&gt;        If you hold yourself completely stiff, you&#39;ll run more slowly.         Keep your arms and shoulders loose, and keep your weight centered.        Keep your head and neck relaxed.         When you try to control your head, the tension can extend down through your spine and the rest of your body.         This can tire you out earlier than you&#39;d tire otherwise.        Instead of focusing on your upper body, try to focus on your stride.         This will help you improve your technique and keep your mind off of your head, shoulders, and neck.    &lt;/p&gt;    &lt;img src=&quot;image/Running_7.png&quot; /&gt;    &lt;h1&gt;7) Let your arms swing in a controlled, compact movement.&lt;/h1&gt;    &lt;p&gt;        This should feel natural--let them swing with your stride.    &lt;/p&gt;    &lt;img src=&quot;image/Running_8.png&quot; /&gt;    &lt;h1&gt;8) Stretch after running.&lt;/h1&gt;    &lt;p&gt;        Stretch all of your muscles, but focus especially on your legs.         Stretch your calves, your quadriceps, your hamstrings, and your core.         Breathe slowly and deeply and focus your attention on each muscle as you stretch it.        Stretching will loosen your tight muscles and lessen the risk of muscle cramps.         It&#39;s important to stretch after any intense workout.        Stretch until you feel relaxed and loose.         Try to stretch for at least five minutes.    &lt;/p&gt;    &lt;img src=&quot;image/Running_9.png&quot; /&gt;    &lt;h1&gt;9) Consider listening to music while you run.&lt;/h1&gt;    &lt;p&gt;        Running to a beat may keep you motivated.         However, some runners contend that an artificial beat will keep you from running in the natural rhythm of your body, and that this can make your running less efficient.        If you listen to music, wear earbuds--nothing loose or bulky.         Hook the earbuds up to an iPod, a smartphone, or any other digital audio device.         Consider buying a strap or a holster to keep your device from coming loose with the impact of running.         Otherwise, consider simply holding it in your hand for security.        Keep in mind that a steady stream of song will distract you from your surroundings.         You may not hear cars, bicycles, or other pedestrians.         If you run while listening to music, you will need to be more visually aware of your surroundings.        Some people prefer to run to slower songs, and some prefer a quicker tempo.         Pick something that makes you excited to run.    &lt;/p&gt;";
            string squatsHTML = "&lt;img src=&quot;image/Squats_1.png&quot; /&gt;    &lt;h1&gt;1) Plant your feet on the ground.&lt;/h1&gt;    &lt;p&gt;        Keep your feet slightly wider than shoulder-width.         Straighten your back.         Angle your feet slightly outward toward 10 and 2 o&#39;clock, not straight ahead.    &lt;/p&gt;    &lt;img src=&quot;image/Squats_2.png&quot; /&gt;    &lt;h1&gt;2) Bend your knees.&lt;/h1&gt;    &lt;p&gt;        Pretend as though you are going to sit back in a chair.         Keep your heels on the ground.         Pull in your abs.         Keep your back straight in a neutral position throughout the exercise.    &lt;/p&gt;    &lt;img src=&quot;image/Squats_3.png&quot; /&gt;    &lt;h1&gt;3) Lower yourself in a controlled manner.&lt;/h1&gt;    &lt;p&gt;        As you go down, push your hips back.         Go as low as your body can while still keeping your shins vertical and your heels on the ground.         From the lower position, push up off your heels and slowly rise up, balancing by leaning forward as necessary.        If you can, aim to lower yourself until your hips sink beneath your knees.         If you are just starting out, you may not be flexible enough to go this low.         Work your way up to this level.        Inhale as you lower. Exhale as you rise.        Look forward as you squat to help keep your form correct.        Extend your arms straight forward to help your balance.         This will also help you keep your shins vertical.    &lt;/p&gt;    &lt;img src=&quot;image/Squats_4.png&quot; /&gt;    &lt;h1&gt;4) Repeat.&lt;/h1&gt;    &lt;p&gt;        If you&#39;re a beginner, you may want to aim for 10 reps.         If you&#39;re fit, you can aim for 15-30 reps each set.         Do one to three sets.         Remember to rest between sets.    &lt;/p&gt;";

            // Seed some exercises. 
            Exercise running = new Exercise { Name = "Running",  DistanceMeasurementsValid = true,  TimeMeasurementsValid = true,  RepMeasurementsValid = false, WeightMeasurementsValid = false, HTMLDescription = runningHTML };
            Exercise squats  = new Exercise { Name = "Squats",   DistanceMeasurementsValid = false, TimeMeasurementsValid = false, RepMeasurementsValid = true,  WeightMeasurementsValid = true, HTMLDescription = squatsHTML };
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeWorkOut.Models
{
    public class Goal
    {
        // Database generated
        public int GoalID { get; set; }

        // Foreign Key
        public int ExerciseID { get; set; }
        public Exercise Exercise { get; set; }

        // The target a user is hoping to acheive for this goal.
        //   NOTE:  This Measurement should not be stored in the Measurements table of the DB
        public Measurement TargetMeasurement { get; set; }

        // Optional parameter if the user wants to set a deadline for when to hit their goal.
        public DateTime? Deadline { get; set; }

        // Keeps track of whether the user has acheived this goal
        public bool Completed { get; set; }
    }
}

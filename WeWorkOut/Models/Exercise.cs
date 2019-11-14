using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeWorkOut.Models
{
    public class Exercise
    {    
        // Primary key.  Database generated
        public string ExerciseID { get; }
        
        // The name of the excercise (i.e. running, deadlifts)
        public string Name { get; set; }

        // Acceptable units that can be used to measure this exercise.
        //  These should be normalized by using all CAPS (i.e. MI, LBS, MIN)
        public List<string> AcceptableUnits { get; set; }

        // Creates a one to many relationship.  One exercise can have many records.
        public ICollection<ExerciseRecord> ExerciseRecords { get; set; }

    }
}

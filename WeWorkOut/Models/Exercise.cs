using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeWorkOut.Models
{
    public class Exercise
    {    
        // Primary key.  Database generated
        [Key]
        public int ExerciseID { get; set; }
        
        // The name of the excercise (i.e. running, deadlifts)
        public string Name { get; set; }
        
        // Records the possible ways an exercise can be measured.
        //   Ex: Can running be measured by distance? Yes.
        //       Can running be measured by weight?   No.
        public bool DistanceMeasurementsValid { get; set; }
        public bool TimeMeasurementsValid { get; set; }
        public bool WeightMeasurementsValid { get; set; }
        public bool RepMeasurementsValid { get; set; }

        //String Containing HTML for that Exercise
        public string HTMLDescription { get; set; }

        // Creates a one to many relationship.  One exercise can have many records.
        public ICollection<ExerciseRecord> ExerciseRecords { get; set; }

        public ICollection<Goal> Goals { get; set; }

    }
}

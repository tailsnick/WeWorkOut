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
        
        public bool AcceptsDistanceMeasurements { get; set; }
        public bool AcceptsTimeMeasurements { get; set; }
        public bool AcceptsWeightMeasurements { get; set; }
        public bool AcceptsRepMeasurements { get; set; }

        // Creates a one to many relationship.  One exercise can have many records.
        public ICollection<ExerciseRecord> ExerciseRecords { get; set; }

        public ICollection<Goal> Goals { get; set; }

    }
}

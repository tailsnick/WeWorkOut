using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeWorkOut.Models
{
    public class ExerciseRecord
    {  
        // Primary key
        [Key]
        public int ExerciseRecordID { get; set; }  

        // Foreign key
        public int ExcerciseID { get; set; }                 
        public Exercise Exercise { get; set; }        
        
        public DateTime SubmitDate { get; set; }

        public string DistanceUnits { get; set; }
        public double? DistanceQuantity { get; set; }

        public string TimeUnits { get; set; }
        public double? TimeQuantity { get; set; }

        public string WeightUnits { get; set; }
        public double? WeightQuantity { get; set; }

        public string RepUnits { get; set; }
        public double? RepQuantity { get; set; }
    }
}

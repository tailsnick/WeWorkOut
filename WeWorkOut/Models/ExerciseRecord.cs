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
        
        // Ties an exercise record to the user that created it.  This is the same value
        //   as the "ID" column of that IdentityUser
        public string UserID { get; set; }
        
        public DateTime SubmitDate { get; set; }

        // These are intentionally nullable values.  If the exercise is running, it cannot be
        //   measured in weight or reps.  In these cases WeightQuantity and RepQuantity would be
        //   null.  Values can also be null if the user chooses not to record something.  For example,
        //   the user may only care about recording running time, not distance.
        public double? DistanceQuantity { get; set; }
        public double? TimeQuantity { get; set; }
        public double? WeightQuantity { get; set; }
        public double? RepQuantity { get; set; }
    }
}

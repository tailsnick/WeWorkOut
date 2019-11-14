using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeWorkOut.Models
{
    public class ExerciseRecord
    {  
        // Primary key
        public int ExerciseRecordID { get; set; }  

        // Foreign key
        public int ExcerciseID { get; set; }                 
        public Exercise Exercise { get; set; }        
        
        public DateTime SubmitDate { get; set; }

        public ICollection<Measurement> Measurements { get; set; }






    }
}

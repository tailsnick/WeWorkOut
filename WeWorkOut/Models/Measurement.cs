using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeWorkOut.Models
{
    public class Measurement
    {
        // Primary Key
        public int MeasurementID { get; set; }
        
        // Foreign Key
        public int ExerciseRecordID { get; set; }
        public ExerciseRecord ExerciseRecord { get; set; }
        
        // Describes the quantity of Units completed
        public int Quantity { get; set; }

        // The unit type (feet, lbs, minutes) for the measurement
        public string Units { get; set; }

    }
}

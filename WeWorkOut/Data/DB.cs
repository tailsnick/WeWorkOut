using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeWorkOut.Models;

namespace WeWorkOut.Data
{
    public class DB : DbContext
    {
        public DB (DbContextOptions<DB> options)
            : base(options)
        {
        }

        public DbSet<Exercise> Exercise { get; set; }

        public DbSet<ExerciseRecord> ExerciseRecord { get; set; }
        
        public DbSet<Goal> Goal { get; set; }
    }
}

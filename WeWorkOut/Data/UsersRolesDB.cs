using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeWorkOut.Areas.Identity;

namespace WeWorkOut.Data
{
    public class UsersRolesDB : IdentityDbContext<ApplicationUser>
    {
        public UsersRolesDB(DbContextOptions<UsersRolesDB> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

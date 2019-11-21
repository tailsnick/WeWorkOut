using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WeWorkOut.Data
{
    public class UsersRolesDB : IdentityDbContext
    {
        public UsersRolesDB(DbContextOptions<UsersRolesDB> options)
            : base(options)
        {
        }
    }
}

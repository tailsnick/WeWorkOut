using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeWorkOut.Areas.Identity
{
    // Our application uses ApplicationUser instead of IdentityUser.  ApplicationUsers builds on
    //   IdentityUser by adding additional field(s) that our specific to our application
    public class ApplicationUser : IdentityUser
    {
        // Whether the user wants their measurements to be stored in metric or imperial units.
        //   Because bools default to 'false', users will default to imperial units unless they change it.
        [PersonalData]
        public bool UseMetricUnits { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string First_Name { get; set; }  
        public string Last_Name { get; set; }
        public string? photo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelVM.StudentVM
{
    public class RegisterStudent
    {
        [Required]

        public string Name { get; set; } 
        [Required]

        public int age { get; set; }

        [Required]

        public string Address { get; set; }
        [Required]

        public string Phone { get; set; }
        [Required]

        public string email { get; set; }
    }
}

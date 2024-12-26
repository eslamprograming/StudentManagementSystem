using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelVM.AuthVM
{
    public class RegisterModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string First_Name { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string Last_Name { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(128)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Password { get; set; }
    }
}

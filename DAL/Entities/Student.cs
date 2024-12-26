using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]

        public string Phone { get; set; }
        [Required]

        public string email { get; set; }

        public ICollection<Subject>? Subjects { get; set; }

    }
}

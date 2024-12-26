using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        [Required]
        [MaxLength(100)]
        public string SubjectName { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public ICollection<Student>? Students { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }

        [Required]
        [MaxLength(100)]
        public string SubjectName { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        [JsonIgnore]
        public ICollection<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();
    }
}

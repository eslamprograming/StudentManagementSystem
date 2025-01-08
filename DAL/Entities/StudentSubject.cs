using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class StudentSubject
    {
        public int StudentId { get; set; }
        public Student students { get; set; }
        public int SubjectId { get; set; }
        public Subject subjects { get; set; }
        public double Grade { get; set; }
    }
}

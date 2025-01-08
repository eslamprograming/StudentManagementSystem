using BLL.IService;
using DAL.Entities;
using DAL.IRepo;
using DAL.ModelVM.SheardModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class StudentSubjectGradeService: IStudentSubjectGradeService
    {
        private readonly IStudentSubjectGrades studentSubjectGrades;

        public StudentSubjectGradeService(IStudentSubjectGrades studentSubjectGrades)
        {
            this.studentSubjectGrades = studentSubjectGrades;
        }

        public async Task<Response<StudentSubject>> AddStudentGradeInSubject(int Student_Id, int Subject_Id, double Grade)
        {
            var result = await studentSubjectGrades.AddStudentGradeInSubject(Student_Id,Subject_Id,Grade);
            return result;
        }

        public async Task<Response<StudentSubject>> DeleteStudentGradeInSubject(int Student_Id, int Subject_Id)
        {
            var result = await studentSubjectGrades.DeleteStudentGradeInSubject(Student_Id, Subject_Id);
            return result;
        }

        public async Task<Response<StudentSubject>> GetAllStudent(int Student_Id)
        {
            var result = await studentSubjectGrades.GetAllStudent(Student_Id);
            return result;
        }

        public async Task<Response<StudentSubject>> UpdateStudentGradeInSubject(int Student_Id, int Subject_Id, double Grade)
        {
            var result = await studentSubjectGrades.UpdateStudentGradeInSubject(Student_Id, Subject_Id, Grade);
            return result;
        }
    }
}

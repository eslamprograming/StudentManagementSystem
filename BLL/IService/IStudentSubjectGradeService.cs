using DAL.Entities;
using DAL.ModelVM.SheardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface IStudentSubjectGradeService
    {
        Task<Response<StudentSubject>> AddStudentGradeInSubject(int Student_Id, int Subject_Id, double Grade);
        Task<Response<StudentSubject>> UpdateStudentGradeInSubject(int Student_Id, int Subject_Id, double Grade);
        Task<Response<StudentSubject>> DeleteStudentGradeInSubject(int Student_Id, int Subject_Id);
        Task<Response<StudentSubject>> GetAllStudent(int Student_Id);
    }
}

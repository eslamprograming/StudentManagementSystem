using DAL.Entities;
using DAL.ModelVM.SheardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface IStudentSujectService
    {
        Task<Response<Student>> AddSujectsToStudentAsync(int Student_Id, List<int> subjects);
        Task<Response<Student>> UpdateSujectsToStudentAsync(int Student_Id, int OldsubjectsId, int newsubject_Id);
        Task<Response<Student>> DeleteSujectsToStudentAsync(int Student_Id, int subject);
        Task<Response<List<Subject>>> GetAllSubjectsForStudentAsync(int Student_Id);
    }
}

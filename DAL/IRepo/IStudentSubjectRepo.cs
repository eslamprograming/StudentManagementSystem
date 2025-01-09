using DAL.Entities;
using DAL.ModelVM.SheardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface IStudentSubjectRepo
    {
        Task<Response<Student>> AddSujectsToStudentAsync(int Student_Id,int subjectsId);
        Task<Response<Student>> UpdateSujectsToStudentAsync(int Student_Id, int OldsubjectsId, int newsubject_Id);
        Task<Response<Student>> DeleteSujectsToStudentAsync(int Student_Id,int SubjectId);
        Task<Response<Subject>> GetAllSubjectsForStudentAsync(int Student_Id);
    }
}

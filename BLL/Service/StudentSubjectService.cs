using BLL.IService;
using DAL.Entities;
using DAL.IRepo;
using DAL.ModelVM.SheardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class StudentSubjectService:IStudentSujectService
    {
        private readonly IStudentSubjectRepo _studentSujectService;

        public StudentSubjectService(IStudentSubjectRepo studentSujectService)
        {
            _studentSujectService = studentSujectService;
        }

        public async Task<Response<Student>> AddSujectsToStudentAsync(int Student_Id, List<int> subjects)
        {
            var result = await _studentSujectService.AddSujectsToStudentAsync(Student_Id, subjects);
            return result;
        }

        public async Task<Response<Student>> DeleteSujectsToStudentAsync(int Student_Id, int subject)
        {
            var result = await _studentSujectService.DeleteSujectsToStudentAsync(Student_Id, subject);
            return result;
        }

        public async Task<Response<List<Subject>>> GetAllSubjectsForStudentAsync(int Student_Id)
        {
            var result = await _studentSujectService.GetAllSubjectsForStudentAsync(Student_Id);
            return result;
        }

        public async Task<Response<Student>> UpdateSujectsToStudentAsync(int Student_Id, int OldsubjectsId, int newsubject_Id)
        {
            var result = await _studentSujectService.UpdateSujectsToStudentAsync(Student_Id, OldsubjectsId,newsubject_Id);
            return result;
        }
    }
}

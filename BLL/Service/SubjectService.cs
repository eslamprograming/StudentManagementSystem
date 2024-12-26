using BLL.IService;
using DAL.Entities;
using DAL.IRepo;
using DAL.ModelVM.SheardModel;
using DAL.ModelVM.SubjectVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class SubjectService:ISupjectService
    {
        private readonly ISubjectRepo _SubjectRepo;

        public SubjectService(ISubjectRepo SubjectRepo)
        {
            _SubjectRepo = SubjectRepo;
        }

        public async Task<Response<Subject>> CreateSubjectAsync(RegisterSubject SubjectVM)
        {
            try
            {
                if (SubjectVM == null)
                {
                    return new Response<Subject>()
                    {
                        success = false,
                        statuscode = "400",
                        message = "name and age is Null"
                    };
                }
                Subject Subject = new Subject();
                Subject.SubjectName = SubjectVM.SubjectName;
                Subject.Description = SubjectVM.Description;

                var result = await _SubjectRepo.CreateSubjectAsync(Subject);
                return result;
            }
            catch (Exception ex)
            {
                return new Response<Subject>()
                {
                    success = false,
                    message = ex.Message,
                    statuscode = "500"
                };
            }
        }

        public async Task<Response<Subject>> DeleteSubjectAsync(int Subject_Id)
        {
            try
            {
                var result = await _SubjectRepo.DeleteSubjectAsync(Subject_Id);
                return result;
            }
            catch (Exception ex)
            {
                return new Response<Subject>()
                {
                    success = false,
                    message = ex.Message,
                    statuscode = "500"
                };
            }
        }

        public async Task<Response<Subject>> GetAllSubjectAsync(int GroupNumber)
        {
            try
            {
                var result = await _SubjectRepo.GetAllSubjectAsync(GroupNumber);
                return result;
            }
            catch (Exception ex)
            {
                return new Response<Subject>()
                {
                    success = false,
                    message = ex.Message,
                    statuscode = "500"
                };
            }
        }

        public async Task<Response<Subject>> GetSubjectAsync(int Subject_Id)
        {
            try
            {
                var result = await _SubjectRepo.GetSubjectAsync(Subject_Id);
                return result;
            }
            catch (Exception ex)
            {
                return new Response<Subject>()
                {
                    success = false,
                    message = ex.Message,
                    statuscode = "500"
                };
            }
        }

        public async Task<Response<Subject>> UpdateSubjectAsync(int Subject_Id, RegisterSubject SubjectVM)
        {
            try
            {
                Subject Subject = new Subject();
                Subject.SubjectId = Subject_Id;
                Subject.SubjectName = SubjectVM.SubjectName;
                Subject.Description = SubjectVM.Description;

                var result = await _SubjectRepo.UpdateSubjectAsync(Subject);
                return result;
            }
            catch (Exception ex)
            {
                return new Response<Subject>()
                {
                    success = false,
                    message = ex.Message,
                    statuscode = "500"
                };
            }
        }
    }
}

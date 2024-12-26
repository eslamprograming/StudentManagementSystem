using DAL.Entities;
using DAL.ModelVM.SheardModel;
using DAL.ModelVM.SubjectVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface ISupjectService
    {
        Task<Response<Subject>> CreateSubjectAsync(RegisterSubject Subject);
        Task<Response<Subject>> UpdateSubjectAsync(int Subject_Id, RegisterSubject Subject);
        Task<Response<Subject>> DeleteSubjectAsync(int Subject_Id);
        Task<Response<Subject>> GetAllSubjectAsync(int GroupNumber);
        Task<Response<Subject>> GetSubjectAsync(int Subject_Id);
    }
}

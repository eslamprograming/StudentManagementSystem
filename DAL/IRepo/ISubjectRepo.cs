using DAL.Entities;
using DAL.ModelVM.SheardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface ISubjectRepo
    {
        Task<Response<Subject>> CreateSubjectAsync(Subject Subject);
        Task<Response<Subject>> UpdateSubjectAsync(Subject Subject);
        Task<Response<Subject>> DeleteSubjectAsync(int Subject_Id);
        Task<Response<Subject>> GetAllSubjectAsync(int GroupNumber);
        Task<Response<Subject>> GetSubjectAsync(int Subject_Id);
    }
}

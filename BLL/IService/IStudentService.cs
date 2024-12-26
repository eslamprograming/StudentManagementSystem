using DAL.Entities;
using DAL.ModelVM.SheardModel;
using DAL.ModelVM.StudentVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface IStudentService
    {
        Task<Response<Student>> CreateStudentAsync(RegisterStudent Student);
        Task<Response<Student>> UpdateStudentAsync(int Student_Id,RegisterStudent Student);
        Task<Response<Student>> DeleteStudentAsync(int Student_Id);
        Task<Response<Student>> GetAllStudentAsync(int GroupNumber);
        Task<Response<Student>> GetStudentAsync(int Student_Id);
    }
}

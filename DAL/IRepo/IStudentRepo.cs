using DAL.Entities;
using DAL.ModelVM.SheardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface IStudentRepo
    {
        Task<Response<Student>> CreateStudentAsync(Student Student);    
        Task<Response<Student>> UpdateStudentAsync(Student Student);    
        Task<Response<Student>> DeleteStudentAsync(int Student_Id);    
        Task<Response<Student>> GetAllStudentAsync(int GroupNumber);    
        Task<Response<Student>> GetStudentAsync(int Student_Id);
    }
}

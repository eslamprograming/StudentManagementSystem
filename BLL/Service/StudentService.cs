using BLL.IService;
using DAL.Entities;
using DAL.IRepo;
using DAL.ModelVM.SheardModel;
using DAL.ModelVM.StudentVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo _studentRepo;

        public StudentService(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public async Task<Response<Student>> CreateStudentAsync(RegisterStudent Student)
        {
            try
            {
                if (Student == null) {
                    return new Response<Student>()
                    {
                        success = false,
                        statuscode="400",
                        message="name and age is Null"
                    };
                }
                Student student = new Student();
                student.Name=Student.Name;
                student.Age = Student.age;
                student.Address=Student.Address;
                student.Phone = Student.Phone;
                student.email = Student.email;
                var result = await _studentRepo.CreateStudentAsync(student);
                return result;
            }
            catch (Exception ex)
            {
                return new Response<Student>()
                {
                    success = false,
                    message = ex.Message,
                    statuscode = "500"
                };
            }
        }

        public async Task<Response<Student>> DeleteStudentAsync(int Student_Id)
        {
            try
            {
                var result = await _studentRepo.DeleteStudentAsync(Student_Id);
                return result;
            }
            catch (Exception ex)
            {
                return new Response<Student>()
                {
                    success = false,
                    message = ex.Message,
                    statuscode = "500"
                };
            }
        }

        public async Task<Response<Student>> GetAllStudentAsync(int GroupNumber)
        {
            try
            {
                var result = await _studentRepo.GetAllStudentAsync(GroupNumber);
                return result;
            }
            catch (Exception ex)
            {
                return new Response<Student>()
                {
                    success = false,
                    message = ex.Message,
                    statuscode = "500"
                };
            }
        }

        public async Task<Response<Student>> GetStudentAsync(int Student_Id)
        {
            try
            {
                var result = await _studentRepo.GetStudentAsync(Student_Id);
                return result;
            }
            catch (Exception ex)
            {
                return new Response<Student>()
                {
                    success = false,
                    message = ex.Message,
                    statuscode = "500"
                };
            }
        }

        public async Task<Response<Student>> UpdateStudentAsync(int Student_Id, RegisterStudent Student)
        {
            try
            {
                Student student = new Student();
                student.StudentId = Student_Id;
                student.Name = Student.Name;
                student.Age = Student.age;
                student.Address = Student.Address;
                student.Phone = Student.Phone;
                student.email = Student.email;
                var result = await _studentRepo.UpdateStudentAsync(student);
                return result;
            }
            catch (Exception ex)
            {
                return new Response<Student>()
                {
                    success = false,
                    message = ex.Message,
                    statuscode = "500"
                };
            }
        }
    }
}

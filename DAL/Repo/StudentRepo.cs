using DAL.DBContext;
using DAL.Entities;
using DAL.IRepo;
using DAL.ModelVM.SheardModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class StudentRepo : IStudentRepo
    {
        private readonly ApplicationDBContext db;

        public StudentRepo(ApplicationDBContext db)
        {
            this.db = db;
        }

        public async Task<Response<Student>> CreateStudentAsync(Student Student)
        {
            try
            {
                if (Student != null)
                {
                    await db.Students.AddAsync(Student);
                    await db.SaveChangesAsync();


                    return new Response<Student>()
                    {
                        success = true,
                        statuscode = "200"
                    };
                }
                return new Response<Student>()
                {
                    success = false,
                    message = "Student Is Not Valid",
                    statuscode = "400"
                };
            }
            catch (Exception ex)
            {
                return new Response<Student>()
                {
                    success= false,
                    message=ex.Message,
                    statuscode="500"
                };
            }
        }

        public async Task<Response<Student>> DeleteStudentAsync(int Student_Id)
        {
            try
            {
                if (Student_Id != null)
                {
                    var Studnet = await db.Students.FindAsync(Student_Id);
                    if (Studnet != null)
                    {
                        db.Students.Remove(Studnet);
                        await db.SaveChangesAsync();


                        return new Response<Student>()
                        {
                            success = true,
                            statuscode = "200"
                        };
                    }
                    else
                    {
                        return new Response<Student>()
                        {
                            success = false,
                            message = "Student Is Not exist",
                            statuscode = "400"
                        };
                    }
                }
                return new Response<Student>()
                {
                    success = false,
                    message = "Student Is Null",
                    statuscode = "400"
                };
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

        public async Task<Response<Student>> GetAllStudentAsync(int groupNumber)
        {
            try
            {
                if (groupNumber > 0)
                {
                    int studentsCount = await db.Students.CountAsync();
                    int groupCount = (int)Math.Ceiling(studentsCount / 10.0);

                    if (groupNumber > groupCount)
                    {
                        return new Response<Student>()
                        {
                            success = false,
                            message = "The requested group does not exist.",
                            statuscode = "400"
                        };
                    }

                    var students = await db.Students
                        .Skip((groupNumber - 1) * 10)
                        .Take(10)
                        .ToListAsync();

                    return new Response<Student>()
                    {
                        success = true,
                        statuscode = "200",
                        groups = groupCount,
                        values = students
                    };
                }
                else
                {
                    return new Response<Student>()
                    {
                        success = false,
                        message = "Group number must be greater than 0.",
                        statuscode = "400"
                    };
                }
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
                if (Student_Id != null)
                {
                    var Student = await db.Students.FindAsync(Student_Id);
                    if (Student != null)
                    {
                        return new Response<Student>()
                        {
                            success = true,
                            statuscode = "200",
                            Value = Student
                        };
                    }
                    else
                    {
                        return new Response<Student>()
                        {
                            success = false,
                            statuscode = "400",
                            message="Studnet is Not Found"
                        };
                    }
                }
                return new Response<Student>()
                {
                    success = false,
                    message = "Student Is Not Valid",
                    statuscode = "400"
                };
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

        public async Task<Response<Student>> UpdateStudentAsync(Student Student)
        {
            try
            {
                if (Student != null)
                {
                    var OldStudent = await db.Students.FindAsync(Student.StudentId);
                    if (OldStudent != null)
                    {
                        OldStudent.Name = Student.Name;
                        OldStudent.Age = Student.Age;
                        OldStudent.Address = Student.Address;
                        OldStudent.Phone = Student.Phone;
                        OldStudent.email = Student.email;
                        await db.SaveChangesAsync();
                        return new Response<Student>()
                        {
                            success = true,
                            statuscode = "200"
                        };
                    }
                    else
                    {

                        return new Response<Student>()
                        {
                            success = false,
                            statuscode = "400",
                            message="Student Can not found"
                        };
                    }
                }
                return new Response<Student>()
                {
                    success = false,
                    message = "Student Is Not Valid",
                    statuscode = "400"
                };
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

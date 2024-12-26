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
    public class StudentSubjectRepo:IStudentSubjectRepo
    {
        private readonly ApplicationDBContext db;

        public StudentSubjectRepo(ApplicationDBContext db)
        {
            this.db = db;
        }

        public async Task<Response<Student>> AddSujectsToStudentAsync(int Student_Id, List<int> subjectsId)
        {
            using var transaction = await db.Database.BeginTransactionAsync();
            try
            {
                var student = await db.Students.Include(s => s.Subjects).FirstOrDefaultAsync(s => s.StudentId == Student_Id);
                if (student == null)
                {
                    return new Response<Student>()
                    {
                        success = false,
                        statuscode = "400",
                        message = "Student not exist"
                    };
                }

                var subjects = await db.Subjects.Where(s => subjectsId.Contains(s.SubjectId)).ToListAsync();
                foreach (var subject in subjects)
                {
                    if (!student.Subjects.Contains(subject)) // Avoid duplicate additions
                    {
                        student.Subjects.Add(subject);
                    }
                }

                await db.SaveChangesAsync();
                await transaction.CommitAsync();

                return new Response<Student>()
                {
                    success = true,
                    statuscode = "200",
                    message = "Subjects added successfully."
                };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new Response<Student>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Student>> DeleteSujectsToStudentAsync(int Student_Id, int subjectId)
        {
            try
            {
                var student = await db.Students
                    .Include(s => s.Subjects)
                    .FirstOrDefaultAsync(s => s.StudentId == Student_Id);

                if (student == null)
                {
                    return new Response<Student>()
                    {
                        success = false,
                        statuscode = "400",
                        message = "Student not exist"
                    };
                }

                var subject = await db.Subjects.FindAsync(subjectId);

                if (subject == null)
                {
                    return new Response<Student>()
                    {
                        success = false,
                        statuscode = "400",
                        message = "Subject not exist"
                    };
                }

                if (!student.Subjects.Contains(subject))
                {
                    return new Response<Student>()
                    {
                        success = false,
                        statuscode = "400",
                        message = "Subject is not associated with the student"
                    };
                }

                student.Subjects.Remove(subject);
                await db.SaveChangesAsync();

                return new Response<Student>()
                {
                    success = true,
                    statuscode = "200",
                    message = "Subject removed successfully."
                };
            }
            catch (Exception ex)
            {
                return new Response<Student>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<List<Subject>>> GetAllSubjectsForStudentAsync(int studentId)
        {
            try
            {
                var subjects = await db.Students
                                        .Where(s => s.StudentId == studentId)
                                        .SelectMany(s => s.Subjects)
                                        .ToListAsync();

                if (!subjects.Any())
                {
                    return new Response<List<Subject>>()
                    {
                        success = false,
                        statuscode = "404",
                        message = "No subjects found for the specified student."
                    };
                }

                return new Response<List<Subject>>()
                {
                    success = true,
                    statuscode = "200",
                    Value = subjects
                };
            }
            catch (Exception ex)
            {
                return new Response<List<Subject>>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }
        public async Task<Response<Student>> UpdateSujectsToStudentAsync(int Student_Id, List<int> subjectsId)
        {
            try
            {
                // تحميل الطالب مع المواد المرتبطة
                var student = await db.Students
                    .Include(s => s.Subjects)
                    .FirstOrDefaultAsync(s => s.StudentId == Student_Id);

                if (student == null)
                {
                    return new Response<Student>()
                    {
                        success = false,
                        statuscode = "400",
                        message = "Student not exist"
                    };
                }

                // جلب المواد بناءً على قائمة المعرفات
                var subjects = await db.Subjects
                    .Where(s => subjectsId.Contains(s.SubjectId))
                    .ToListAsync();

                // التحقق من وجود جميع المواد
                if (subjects.Count != subjectsId.Count)
                {
                    return new Response<Student>()
                    {
                        success = false,
                        statuscode = "400",
                        message = "One or more subjects not found"
                    };
                }

                // تحديث قائمة المواد المرتبطة بالطالب
                student.Subjects.Clear(); // إزالة المواد القديمة
                foreach (var subject in subjects)
                {
                    student.Subjects.Add(subject);
                }

                // حفظ التغييرات
                await db.SaveChangesAsync();

                return new Response<Student>()
                {
                    success = true,
                    statuscode = "200",
                    message = "Subjects updated successfully.",
                    
                };
            }
            catch (Exception ex)
            {
                return new Response<Student>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }
    }
}

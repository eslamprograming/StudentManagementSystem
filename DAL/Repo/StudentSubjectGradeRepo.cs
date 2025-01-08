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
    public class StudentSubjectGradeRepo : IStudentSubjectGrades
    {
        private readonly ApplicationDBContext db;

        public StudentSubjectGradeRepo(ApplicationDBContext db)
        {
            this.db = db;
        }

        public async Task<Response<StudentSubject>> AddStudentGradeInSubject(int Student_Id, int Subject_Id, double Grade)
        {
            try
            {
                var studentSubject1 = await db.StudentSubjects
                    .Where(n => n.StudentId == Student_Id && n.SubjectId == Subject_Id).FirstOrDefaultAsync();
                studentSubject1.Grade = Grade;
                await db.SaveChangesAsync();
                return new Response<StudentSubject>()
                {
                    success = true,
                    statuscode = "200"
                };
            }
            catch (Exception ex)
            {
                return new Response<StudentSubject>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<StudentSubject>> DeleteStudentGradeInSubject(int Student_Id, int Subject_Id)
        {
            try
            {
                var studentSubject1 = await db.StudentSubjects
                    .Where(n => n.StudentId == Student_Id && n.SubjectId == Subject_Id).FirstOrDefaultAsync();
                db.StudentSubjects.Remove(studentSubject1);
                await db.SaveChangesAsync();
                return new Response<StudentSubject>()
                {
                    success = true,
                    statuscode = "200"
                };
            }
            catch (Exception ex)
            {
                return new Response<StudentSubject>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<StudentSubject>> GetAllStudent(int Student_Id)
        {
            try
            {
                var subjects = await db.StudentSubjects
                                    .Where(ss => ss.StudentId == Student_Id)
                               .ToListAsync();
                return new Response<StudentSubject>()
                {
                    statuscode="200",
                    success=true,
                    values= subjects
                };
            }
            catch (Exception ex)
            {
                return new Response<StudentSubject>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<StudentSubject>> UpdateStudentGradeInSubject(int Student_Id, int Subject_Id, double Grade)
        {
            try
            {
                var studentSubject1 = await db.StudentSubjects
                    .Where(n => n.StudentId == Student_Id && n.SubjectId == Subject_Id).FirstOrDefaultAsync();
                studentSubject1.Grade = Grade;
                await db.SaveChangesAsync();
                return new Response<StudentSubject>()
                {
                    success = true,
                    statuscode = "200"
                };
            }
            catch (Exception ex)
            {
                return new Response<StudentSubject>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }
    }
}

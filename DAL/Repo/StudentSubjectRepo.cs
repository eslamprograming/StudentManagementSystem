﻿using DAL.DBContext;
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

        public async Task<Response<Student>> AddSujectsToStudentAsync(int Student_Id, int subjectsId)
        {
            using var transaction = await db.Database.BeginTransactionAsync();
            try
            {
                var stsub = await db.StudentSubjects.Where(n => n.StudentId == Student_Id && n.SubjectId == subjectsId).FirstOrDefaultAsync();
                if (stsub != null) {
                    return new Response<Student>()
                    {
                        success = false,
                        statuscode = "400",
                        message = "studend enrolled this subject"
                    };
                }
                StudentSubject studentSubject = new StudentSubject();
                studentSubject.StudentId = Student_Id;
                studentSubject.SubjectId = subjectsId;
                await db.StudentSubjects.AddAsync(studentSubject);
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
                var studentSubject = await db.StudentSubjects.
                    Where(n => n.SubjectId == subjectId && n.StudentId == Student_Id).FirstOrDefaultAsync();

                if (studentSubject == null)
                {
                    return new Response<Student>()
                    {
                        success = false,
                        statuscode = "400",
                        message = "Student not exist"
                    };
                }

                db.StudentSubjects.Remove(studentSubject);
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

        public async Task<Response<Subject>> GetAllSubjectsForStudentAsync(int studentId)
        {
            try
            {
                var subjects = await db.StudentSubjects
                                        .Where(s => s.StudentId == studentId)
                                        .Include(n=>n.subjects).Select(n=>n.subjects)
                                        .ToListAsync();

                if (!subjects.Any())
                {
                    return new Response<Subject>()
                    {
                        success = false,
                        statuscode = "404",
                        message = "No subjects found for the specified student."
                    };
                }

                return new Response<Subject>()
                {
                    success = true,
                    statuscode = "200",
                    values = subjects
                };
            }
            catch (Exception ex)
            {
                return new Response<Subject>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }
        public async Task<Response<Student>> UpdateSujectsToStudentAsync(int Student_Id, int OldsubjectsId,int newsubject_Id)
        {
            try
            {
                StudentSubject obj = await db.StudentSubjects.Where(n => n.StudentId == Student_Id && n.SubjectId== OldsubjectsId).FirstOrDefaultAsync();
                db.StudentSubjects.Remove(obj);
                StudentSubject studentSubject = new StudentSubject();
                studentSubject.StudentId=Student_Id;
                studentSubject.SubjectId = newsubject_Id;
                await db.StudentSubjects.AddAsync(studentSubject);
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

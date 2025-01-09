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
    public class SupjectRepo:ISubjectRepo
    {
        private readonly ApplicationDBContext db;

        public SupjectRepo(ApplicationDBContext db)
        {
            this.db = db;
        }
        public async Task<Response<Subject>> CreateSubjectAsync(Subject Subject)
        {
            try
            {
                if (Subject != null)
                {
                    await db.Subjects.AddAsync(Subject);
                    await db.SaveChangesAsync();


                    return new Response<Subject>()
                    {
                        success = true,
                        statuscode = "200"
                    };
                }
                return new Response<Subject>()
                {
                    success = false,
                    message = "Subject Is Not Valid",
                    statuscode = "400"
                };
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
                if (Subject_Id != null)
                {
                    var Studnet = await db.Subjects.FindAsync(Subject_Id);
                    if (Studnet != null)
                    {
                        db.Subjects.Remove(Studnet);
                        await db.SaveChangesAsync();


                        return new Response<Subject>()
                        {
                            success = true,
                            statuscode = "200"
                        };
                    }
                    else
                    {
                        return new Response<Subject>()
                        {
                            success = false,
                            message = "Subject Is Not exist",
                            statuscode = "400"
                        };
                    }
                }
                return new Response<Subject>()
                {
                    success = false,
                    message = "Subject Is Null",
                    statuscode = "400"
                };
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

        public async Task<Response<Subject>> GetAllSubjectAsync(int groupNumber)
        {
            try
            {
                if (groupNumber > 0)
                {
                    int SubjectsCount = await db.Subjects.CountAsync();
                    int groupCount = (int)Math.Ceiling(SubjectsCount / 10.0);

                    if (groupNumber > groupCount)
                    {
                        return new Response<Subject>()
                        {
                            success = false,
                            message = "The requested group does not exist.",
                            statuscode = "400"
                        };
                    }

                    var Subjects = await db.Subjects
                        //.Skip((groupNumber - 1) * 10)
                        //.Take(10)
                        .ToListAsync();

                    return new Response<Subject>()
                    {
                        success = true,
                        statuscode = "200",
                        groups = groupCount,
                        values = Subjects
                    };
                }
                else
                {
                    return new Response<Subject>()
                    {
                        success = false,
                        message = "Group number must be greater than 0.",
                        statuscode = "400"
                    };
                }
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
                if (Subject_Id != null)
                {
                    var Subject = await db.Subjects.FindAsync(Subject_Id);
                    if (Subject != null)
                    {
                        return new Response<Subject>()
                        {
                            success = true,
                            statuscode = "200",
                            Value = Subject
                        };
                    }
                    else
                    {
                        return new Response<Subject>()
                        {
                            success = false,
                            statuscode = "400",
                            message = "Studnet is Not Found"
                        };
                    }
                }
                return new Response<Subject>()
                {
                    success = false,
                    message = "Subject Is Not Valid",
                    statuscode = "400"
                };
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

        public async Task<Response<Subject>> UpdateSubjectAsync(Subject Subject)
        {
            try
            {
                if (Subject != null)
                {
                    var OldSubject = await db.Subjects.FindAsync(Subject.SubjectId);
                    if (OldSubject != null)
                    {
                        OldSubject.SubjectName = Subject.SubjectName;
                        OldSubject.Description = Subject.Description;
                        await db.SaveChangesAsync();
                        return new Response<Subject>()
                        {
                            success = true,
                            statuscode = "200"
                        };
                    }
                    else
                    {

                        return new Response<Subject>()
                        {
                            success = false,
                            statuscode = "400",
                            message = "Subject Can not found"
                        };
                    }
                }
                return new Response<Subject>()
                {
                    success = false,
                    message = "Subject Is Not Valid",
                    statuscode = "400"
                };
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

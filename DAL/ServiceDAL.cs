using DAL.IRepo;
using DAL.Repo;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class ServiceDAL
    {
        public static IServiceCollection service2(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepo, StudentRepo>();
            services.AddScoped<ISubjectRepo, SupjectRepo>();
            services.AddScoped<IStudentSubjectRepo, StudentSubjectRepo>();
            services.AddScoped<IStudentSubjectGrades, StudentSubjectGradeRepo>();
            return services;
        }
    }
}

using BLL.IService;
using BLL.Service;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class ServiceBLL
    {
        public static IServiceCollection service1(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ISupjectService, SubjectService>();
            services.AddScoped<IStudentSujectService, StudentSubjectService>();
            services.AddScoped<IStudentSubjectGradeService, StudentSubjectGradeService>();
            return services;
        }
    }
}

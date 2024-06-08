using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Repositories;
using ServiceLayer.Services;
using ServiceLayer.Services.Interface;

namespace ServiceLayer.Extensions
{
    public static class ServiceExtension
    {
        public static void ServiceAdd(this IServiceCollection service)
        {
            service.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            service.AddScoped<ILessonService, LessonService>();
            service.AddScoped<IExamService, ExamService>();
            service.AddScoped<IStudentService, StudentService>();
        }
    }
}

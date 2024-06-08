using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Dtos.Exam;
using ServiceLayer.Dtos.Lesson;
using ServiceLayer.Dtos.Student;
using ServiceLayer.Validations;

namespace ServiceLayer.Extensions
{
    public static class ValidateExtension
    {
        public static void ValidateAdd(this IServiceCollection service)
        {
            service.AddScoped<IValidator<CreateExamDto>, CreateExamDtoValidator>();
            service.AddScoped<IValidator<CreateLessonDto>, CreateLessonDtoValidator>();
            service.AddScoped<IValidator<CreateStudentDto>, CreateStudentDtoValidator>();
        }
    }
}

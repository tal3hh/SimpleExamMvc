using AutoMapper;
using DomainLayer.Entities;
using ServiceLayer.Dtos.Exam;
using ServiceLayer.Dtos.Lesson;
using ServiceLayer.Dtos.Student;

namespace ServiceLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Exam, CreateExamDto>().ReverseMap();
            CreateMap<Exam, ExamDto>()
            .ForMember(dest => dest.Lesson,
                opt => opt.MapFrom(src => $"{src.Lesson.lessonName}({src.Lesson.Code})"))
            .ForMember(dest => dest.Student,
                opt => opt.MapFrom(src => $"{src.Student.firstName} {src.Student.lastName}({src.Student.Number})"));

            CreateMap<Student, CreateStudentDto>().ReverseMap();
            CreateMap<Student, StudentDto>()
            .ForMember(dest => dest.fullName,
                opt => opt.MapFrom(src => $"{src.firstName} {src.lastName}"));

            CreateMap<Lesson, CreateLessonDto>().ReverseMap();
            CreateMap<Lesson, LessonDto>()
            .ForMember(dest => dest.teacherFullName,
                opt => opt.MapFrom(src => $"{src.teacherName} {src.teacherSurname}"));
        }
    }
}

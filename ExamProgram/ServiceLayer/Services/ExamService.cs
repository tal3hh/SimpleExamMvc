using AutoMapper;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repositories;
using ServiceLayer.Common.Result;
using ServiceLayer.Dtos.Exam;
using ServiceLayer.Services.Interface;
using System.Runtime.CompilerServices;

namespace ServiceLayer.Services
{
    public class ExamService : IExamService
    {
        private readonly IRepository<Exam> _repo;
        private readonly IRepository<Student> _repoStudent;
        private readonly IRepository<Lesson> _repoLesson;
        private readonly IMapper _mapper;

        public ExamService(IRepository<Exam> repo, IMapper mapper, IRepository<Student> repoStudent, IRepository<Lesson> repoLesson)
        {
            _repo = repo;
            _mapper = mapper;
            _repoStudent = repoStudent;
            _repoLesson = repoLesson;
        }


        public async Task<List<ExamDto>> GetListAsync()
        {
            var list = await _repo.GetListAsync(include: x => x.Include(x=> x.Student).Include(x=> x.Lesson),
                                                orderBy: x=> x.OrderByDescending(x=> x.Id));

            return _mapper.Map<List<ExamDto>>(list);
        }

        public async Task<IResponse> CreateAsync(CreateExamDto dto)
        {
            var entity = _mapper.Map<Exam>(dto);

            if (entity is null) return new Response(RespType.NotFound, "Data tapılmadı.");

            var student = await _repoStudent.GetAsync(predicate: x => x.Id == dto.StudentId);
            var lesson = await _repoLesson.GetAsync(predicate: x => x.Id == dto.LessonId);

            if (student.Grade != lesson.Grade) return new Response(RespType.BadReqest,
                $"'{lesson.Code}' kodlu dərs, '{student.Number}' nömrəli şagirdin sinifinə uyğun deyil. Eyni sinifə aid dərs və şagird seçin.");

            await _repo.CreateAsync(entity);
            await _repo.SaveChangesAsync();

            return new Response(RespType.Success);
        }

        public async Task<IResponse> RemoveAsync(int id)
        {
            var entity = await _repo.GetAsync(predicate: x => x.Id == id);
            if (entity is null) return new Response(RespType.NotFound, "Data tapılmadı.");

            _repo.Remove(entity);
            await _repo.SaveChangesAsync();
            return new Response(RespType.Success);
        }
    }
}

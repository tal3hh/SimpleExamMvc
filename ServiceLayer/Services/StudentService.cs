using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories;
using ServiceLayer.Common.Result;
using ServiceLayer.Dtos.Student;
using ServiceLayer.Services.Interface;

namespace ServiceLayer.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _repo;
        private readonly IMapper _mapper;

        public StudentService(IRepository<Student> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<IResponse> CreateAsync(CreateStudentDto dto)
        {
            var entity = _mapper.Map<Student>(dto);

            if (entity is null) return new Response(RespType.NotFound, "Data tapılmadı.");

            if (await _repo.ExistsAsync(x => x.Number == entity.Number))
                return new Response(RespType.BadReqest, "Şagirdin nömrəsi unikal olmalıdır.Bu nömrə mövcuddur.");

            await _repo.CreateAsync(entity);
            await _repo.SaveChangesAsync();
            return new Response(RespType.Success);
        }

        public async Task<List<StudentDto>> GetListAsync()
        {
            var list = await _repo.GetListAsync(orderBy: x => x.OrderByDescending(x => x.Id));

            return _mapper.Map<List<StudentDto>>(list);
        }

        public async Task<IResponse> RemoveAsync(int number)
        {
            var entity = await _repo.GetAsync(predicate: x => x.Number == number);
            if (entity is null) return new Response(RespType.NotFound, "Data tapılmadı.");

            _repo.Remove(entity);
            await _repo.SaveChangesAsync();
            return new Response(RespType.Success);
        }
    }
}

using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories;
using ServiceLayer.Common.Result;
using ServiceLayer.Dtos.Lesson;
using ServiceLayer.Services.Interface;

namespace ServiceLayer.Services
{
    public class LessonService : ILessonService
    {
        private readonly IRepository<Lesson> _repo;
        private readonly IMapper _mapper;

        public LessonService(IRepository<Lesson> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<IResponse> CreateAsync(CreateLessonDto dto)
        {
            var entity = _mapper.Map<Lesson>(dto);

            if (entity is null) return new Response(RespType.NotFound, "Data tapılmadı.");

            if (await _repo.ExistsAsync(x=> x.Code == entity.Code)) 
                return new Response(RespType.BadReqest, "Dərsin kodu unikal olmalıdır.Bu kod mövcuddur.");

            await _repo.CreateAsync(entity);
            await _repo.SaveChangesAsync();
            return new Response(RespType.Success);
        }


        public async Task<List<LessonDto>> GetListAsync()
        {
            var list = await _repo.GetListAsync(orderBy: x => x.OrderByDescending(x => x.Id));

            return _mapper.Map<List<LessonDto>>(list);
        }


        public async Task<IResponse> RemoveAsync(string code)
        {
            var entity = await _repo.GetAsync(predicate: x => x.Code == code);
            if (entity is null) return new Response(RespType.NotFound, "Data tapılmadı.");

            _repo.Remove(entity);
            await _repo.SaveChangesAsync();
            return new Response(RespType.Success);
        }
    }
}

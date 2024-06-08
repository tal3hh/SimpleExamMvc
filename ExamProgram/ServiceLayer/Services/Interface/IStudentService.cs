using ServiceLayer.Common.Result;
using ServiceLayer.Dtos.Student;

namespace ServiceLayer.Services.Interface
{
    public interface IStudentService
    {
        Task<IResponse> CreateAsync(CreateStudentDto dto);
        Task<List<StudentDto>> GetListAsync();
        Task<IResponse> RemoveAsync(int number);
    }
}

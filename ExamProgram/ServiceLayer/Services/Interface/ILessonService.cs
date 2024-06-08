using ServiceLayer.Common.Result;
using ServiceLayer.Dtos.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interface
{
    public interface ILessonService
    {
        Task<IResponse> CreateAsync(CreateLessonDto dto);
        Task<List<LessonDto>> GetListAsync();
        Task<IResponse> RemoveAsync(string code);
    }
}

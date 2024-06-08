using ServiceLayer.Common.Result;
using ServiceLayer.Dtos.Exam;
using ServiceLayer.Dtos.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interface
{
    public interface IExamService
    {
        Task<IResponse> CreateAsync(CreateExamDto dto);
        Task<List<ExamDto>> GetListAsync();
        Task<IResponse> RemoveAsync(int id);
    }
}

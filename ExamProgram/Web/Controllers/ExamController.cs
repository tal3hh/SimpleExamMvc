using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Dtos.Exam;
using ServiceLayer.Services.Interface;
using ServiceLayer.Common.Result;

namespace Web.Controllers
{
    public class ExamController : Controller
    {
        readonly ILessonService _lessonService;
        readonly IStudentService _studentServcie;
        readonly IExamService _examService;
        public ExamController(ILessonService lessonService, IStudentService studentServcie, IExamService examService)
        {
            _lessonService = lessonService;
            _studentServcie = studentServcie;
            _examService = examService;
        }

        public async Task<IActionResult> Index()
        {
            var lessons = await _lessonService.GetListAsync();
            var students = await _studentServcie.GetListAsync();
            return View((new CreateExamDto(),lessons, students));
        }

        [HttpPost]
        public async Task<IActionResult> Index([Bind(Prefix ="Item1")] CreateExamDto dto)
        {
            var lessons = await _lessonService.GetListAsync();
            var students = await _studentServcie.GetListAsync();
            if (!ModelState.IsValid) return View((dto, lessons, students));

            var result = await _examService.CreateAsync(dto);

            if (result.RespType != RespType.Success)
            {
                ModelState.AddModelError("", result.Message);
                return View((dto, lessons, students));
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _examService.RemoveAsync(id);

            return RedirectToAction("Index", "Home");
        }
    }
}

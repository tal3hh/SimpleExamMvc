using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Interface;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        readonly ILessonService _lessonService;
        readonly IStudentService _studentServcie;
        readonly IExamService _examService;

        public HomeController(ILessonService lessonService, IStudentService studentServcie, IExamService examService)
        {
            _lessonService = lessonService;
            _studentServcie = studentServcie;
            _examService = examService;
        }

        public async Task<IActionResult> Index()
        {
            var lessons = await _lessonService.GetListAsync();
            var students = await _studentServcie.GetListAsync();
            var exams = await _examService.GetListAsync();
            return View((lessons,students,exams));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Common.Result;
using ServiceLayer.Dtos.Student;
using ServiceLayer.Services;
using ServiceLayer.Services.Interface;

namespace Web.Controllers
{
    public class StudentController : Controller
    {
        readonly IStudentService _StudentService;
        public StudentController(IStudentService StudentService)
        {
            _StudentService = StudentService;
        }

        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Index(CreateStudentDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var result = await _StudentService.CreateAsync(dto);

            if (result.RespType != RespType.Success)
            {
                ModelState.AddModelError("", result.Message);
                return View(dto);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Remove(int number)
        {
            await _StudentService.RemoveAsync(number);
            return RedirectToAction("Index", "Home");
        }
    }
}


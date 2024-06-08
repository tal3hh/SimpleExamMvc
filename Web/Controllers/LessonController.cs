using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using ServiceLayer.Common.Result;
using ServiceLayer.Dtos.Lesson;
using ServiceLayer.Services.Interface;

namespace Web.Controllers
{
    public class LessonController : Controller
    {
        readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Index(CreateLessonDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var result = await _lessonService.CreateAsync(dto);

            if (result.RespType != RespType.Success)
            {
                ModelState.AddModelError("", result.Message);
                return View(dto);
            }
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Remove(string code)
        {
            await _lessonService.RemoveAsync(code);

            return RedirectToAction("Index", "Home");
        }
    }
}

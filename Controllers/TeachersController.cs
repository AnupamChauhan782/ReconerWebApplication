using BusinessAcess.IRepos;
using Microsoft.AspNetCore.Mvc;
using ModelData.Models;

namespace ReCornerApplication.Controllers
{
    public class TeachersController : Controller
    {
        private  readonly ITeacherService _service;
        public TeachersController(ITeacherService teacherService)
        {
            this._service = teacherService;
        }
        public async Task<IActionResult> Index()
        {
            var res = await _service.GetAllTeacher();
            return View(res);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                await _service.AddNewTeacher(teacher);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var res=await _service.GetTeacherById(id);
            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                await _service.UpadateTeacher(teacher);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _service.GetTeacherById(id);
            return View(res);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var res = await _service.GetTeacherById(id);
            if(res == null)
            {
                return NotFound();
            }
            await _service.DeleteTeacher(id);
            return RedirectToAction("Index");
            
        }

    }
}

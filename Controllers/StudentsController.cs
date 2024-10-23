using BusinessAcess.IRepos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelData.Models;

namespace ReCornerApplication.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            this._studentService = studentService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var student = await _studentService.GetStudents();
            return View(student);
        }
        
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                await _studentService.AddNewstudent(student);
              return  RedirectToAction("Index");
            }
            return View(student);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentService.GetStudentById(id);

            if (student == null)
            {
                // Return an error page or redirect to an appropriate action (e.g., Index) if the student is not found
                return NotFound(); // You can also redirect to Index or show a custom error message
            }

            return View(student);  // This will display the delete confirmation view
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _studentService.GetStudentById(id);

            if (student == null)
            {
                // Handle the case where the student is not found during the delete action
                return NotFound();
            }

            await _studentService.Deletestudent(id);  // Assuming this method exists in your service

            return RedirectToAction(nameof(Index));  // Redirect to the student index after deletion
        }

        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentService.GetStudentById(id);

            if (student == null)
            {
                return NotFound(); 
            }

            return View(student); 
        }

        [HttpPost, ActionName("Edit")]
        
        public async Task<IActionResult> EditConfirm(int id, Student student)
        {
            // Ensure that the `id` in the URL matches the `student.StudId`
            if (id != student.StudId)
            {
                return BadRequest();  // If the ID doesn't match, return a BadRequest
            }

            // Check if the model is valid
            if (!ModelState.IsValid)
            {
                return View(student);  // Return the view with validation errors if the model is invalid
            }

            // Update the student using the service
            try
            {
                await _studentService.UpdateStudent(student);
            }
            catch (Exception)
            {
               
                return NotFound();
            }

            // Redirect to the list of students after successful update
            return RedirectToAction(nameof(Index));
        }


    }
}

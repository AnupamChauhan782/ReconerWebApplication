using DataAccess.DbContect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelData.Models;
using ModelData.ViewModel;

namespace ReCornerApplication.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly ApplicationDBConect _appliactionDb;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BooksController(ApplicationDBConect applicationDBConect,IWebHostEnvironment webHost)
        {
            this._appliactionDb = applicationDBConect;
            this._webHostEnvironment = webHost;
        }
        public async Task<IActionResult> Index()
        {
            var books = await _appliactionDb.ReBook_table.ToListAsync();
            var bookViewModels = books.Select(b => new BookViewModel
            {
                BookId = b.BookId,
                BookName = b.BookName,
                AuthorName = b.AuthorName,
                Price = b.Price,
                ImagePath = b.ImagePath
            }).ToList();

            return View(bookViewModels);
        }


        [HttpGet]
        public async Task<IActionResult> UploadImg()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadImg(BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                if (bookViewModel.Image != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + bookViewModel.Image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    Directory.CreateDirectory(uploadsFolder);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await bookViewModel.Image.CopyToAsync(fileStream);
                    }
                }

                var book = new Book
                {
                    BookName = bookViewModel.BookName,
                    AuthorName = bookViewModel.AuthorName,
                    Price = bookViewModel.Price,
                    ImagePath = uniqueFileName != null ? "/uploads/" + uniqueFileName : null
                };

                _appliactionDb.ReBook_table.Add(book);
                await _appliactionDb.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(bookViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var book = await _appliactionDb.ReBook_table.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _appliactionDb.ReBook_table.FindAsync(id);
            _appliactionDb.ReBook_table.Remove(book);
            await _appliactionDb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _appliactionDb.ReBook_table.Any(e => e.BookId == id);
        }

    }



}

        
        

    


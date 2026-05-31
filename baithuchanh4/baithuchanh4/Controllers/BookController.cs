using baithuchanh4.Models;
using Microsoft.AspNetCore.Mvc;

namespace baithuchanh4.Controllers
{
    public class BookController : Controller
    {
        private static readonly List<Book> _books = new();

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }

            book.Id = _books.Count + 1;
            _books.Add(book);

            TempData["Success"] = "Thêm sách thành công!";
            return RedirectToAction(nameof(Create));
        }
    }
}

using lession2.Models;
using Microsoft.AspNetCore.Mvc;

namespace lession2.Controllers
{
    public class BookController : Controller
    {
        private static readonly List<Book> Books = new()
        {
            new Book { Id = 1, Name = "Clean Code", Price = 20 },
            new Book { Id = 2, Name = "ASP.NET MVC", Price = 15 },
            new Book { Id = 3, Name = "Design Pattern", Price = 25 }
        };

        public IActionResult Index()
        {
            return View(Books);
        }

        public IActionResult Detail(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }

            book.Id = Books.Count > 0 ? Books.Max(b => b.Id) + 1 : 1;
            Books.Add(book);

            ViewBag.Message = "Thêm sách thành công";
            return View(new Book());
        }
    }
}

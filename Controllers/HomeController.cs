using lession2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace lession2.Controllers
{
    public class HomeController : Controller
    {
        // Thay bằng tên và email của bạn
        private const string StudentName = "Nguyễn Văn Dương";
        private const string StudentEmail = "nguyenvanduong@example.com";

        public IActionResult Index()
        {
            return Content("Welcome to ASP.NET MVC");
        }

        public IActionResult About()
        {
            return Content(StudentName);
        }

        public IActionResult Contact()
        {
            return Content(StudentEmail);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
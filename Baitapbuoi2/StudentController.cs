using lession2.Models;

using Microsoft.AspNetCore.Mvc;



namespace lession2.Controllers

{

    public class StudentController : Controller

    {

        public IActionResult Info()

        {

            ViewBag.Name = "Nguyễn Văn Dũng";

            ViewData["Age"] = 20;



            var student = new Student { Major = "CNTT" };

            return View(student);

        }

    }

}


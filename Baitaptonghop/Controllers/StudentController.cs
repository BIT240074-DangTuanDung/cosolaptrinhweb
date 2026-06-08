using Baitaptonghop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Baitaptonghop.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Nguyễn Văn Anh", Email = "nguyenvanaanh@email.com", Phone = "0901234567" },
            new Student { Id = 2, Name = "Trần Thị Ban", Email = "tranthiban@email.com", Phone = "0912345678" },
            new Student { Id = 3, Name = "Lê Văn Chung", Email = "levanchung@email.com", Phone = "0923456789" }
        };

        private static int nextId = 4;

        public IActionResult Index()
        {
            return View(students);
        }

        public IActionResult Detail(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Id = nextId++;
            students.Add(model);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var student = students.FirstOrDefault(s => s.Id == model.Id);
            if (student == null)
            {
                return NotFound();
            }

            student.Name = model.Name;
            student.Email = model.Email;
            student.Phone = model.Phone;

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            students.Remove(student);
            return RedirectToAction(nameof(Index));
        }
    }
}

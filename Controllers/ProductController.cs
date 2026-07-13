using Microsoft.AspNetCore.Mvc;

namespace lession2.Controllers
{
    public class ProductController : Controller
    {
        // Route: /Product/Detail/5  →  id lấy từ segment URL (route parameter)
        public IActionResult Detail(int? id)
        {
            if (!id.HasValue)
            {
                return Content("Lỗi: Vui lòng truyền id sản phẩm. Ví dụ: /Product/Detail/5");
            }

            return Content($"Product ID = {id.Value}");
        }

        // Route: /Product/Category?name=Laptop  →  name lấy từ query string
        public IActionResult Category(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Content("Lỗi: Vui lòng truyền tên danh mục. Ví dụ: /Product/Category?name=Laptop");
            }

            return Content($"Category = {name}");
        }
    }
}


# Bài 6 – Validation cơ bản

## Giải thích luồng hoạt động

### 1. Model (`Models/Book.cs`)

Model `Book` định nghĩa dữ liệu sách và quy tắc kiểm tra bằng **Data Annotation**:

- `[Required]` trên `Name`: nếu để trống → báo lỗi **"Không được để trống"**
- `[Range(0.01, ...)]` trên `Price`: nếu giá ≤ 0 → báo lỗi **"Giá phải lớn hơn 0"**

Khi người dùng gửi form, ASP.NET Core tự đọc các attribute này và kiểm tra dữ liệu.

### 2. Hiển thị form (GET)

Người dùng truy cập `/Book/Create` → `BookController.Create()` [HttpGet] trả về view `Create.cshtml` với form trống gồm 2 ô: **Tên sách** và **Giá**.

### 3. Gửi form (POST)

Người dùng nhập dữ liệu và bấm **Thêm** → form gửi POST lên `BookController.Create()` [HttpPost].

ASP.NET Core tự động gán dữ liệu từ form vào object `Book` (model binding), rồi chạy validation theo Data Annotation. Kết quả được lưu vào **ModelState**.

### 4. Kiểm tra ModelState trong Controller

```csharp
if (!ModelState.IsValid)
{
    return View(book);  // Dữ liệu không hợp lệ → trả lại form kèm lỗi
}
```

- **ModelState.IsValid = false** → quay lại view, hiển thị thông báo lỗi bên cạnh từng ô input
- **ModelState.IsValid = true** → gán Id, thêm sách vào danh sách, chuyển hướng về form và hiện **"Thêm sách thành công!"**

### 5. Hiển thị lỗi trên View (`Views/Book/Create.cshtml`)

View dùng các tag helper để hiển thị lỗi:

- `asp-validation-for="Name"` → hiện lỗi tên sách
- `asp-validation-for="Price"` → hiện lỗi giá
- `_ValidationScriptsPartial` → hỗ trợ kiểm tra ngay trên trình duyệt trước khi gửi form

### Tóm tắt luồng

```
Người dùng mở form (GET)
    ↓
Nhập dữ liệu → bấm Thêm (POST)
    ↓
ASP.NET bind dữ liệu vào Book → validate theo Data Annotation → lưu vào ModelState
    ↓
Controller kiểm tra ModelState.IsValid
    ├─ Không hợp lệ → trả lại form + thông báo lỗi
    └─ Hợp lệ       → lưu sách → thông báo thành công
```

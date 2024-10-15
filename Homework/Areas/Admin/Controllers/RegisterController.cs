using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Homework.Areas.Admin.Models;
using Homework.Models;
using Homework.Utilities;

namespace Homework.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly DataContext _context;

        public RegisterController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminUser user)
        {
            if (user == null)
            {
                return NotFound();
            }

            // Kiểm tra sự tồn tại của email trong CSDL
            var check = _context.AdminUsers.Where(m => m.Email == user.Email).FirstOrDefault();
            if (check != null)
            {
                // Hiển thị thông báo, có thể làm cách khác
                Functions._MessageEmail = "Duplicate Email!";
                return RedirectToAction("Index", "Register");
            }

            // Nếu không tồn tại thì thêm vào CSDL
                Functions._MessageEmail = string.Empty;

            // Mã hóa mật khẩu
            user.PasswordHash = Functions.MD5Password(user.PasswordHash); // Giả định rằng bạn có thuộc tính PasswordHash

            _context.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login"); // Đường dẫn tới trang đăng nhập
        }
    }
}

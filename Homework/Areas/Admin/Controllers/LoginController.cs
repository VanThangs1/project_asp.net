using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Homework.Areas.Admin.Models;
using Homework.Models;
using Homework.Utilities;

namespace Homework.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly DataContext _context;

        public LoginController(DataContext context)
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

            string pw = Functions.MD5Password(user.PasswordHash);
            // Kiểm tra sự tồn tại của email và mật khẩu trong CSDL
            var check = _context.AdminUsers.Where(m => (m.Email == user.Email) && (m.PasswordHash == pw)).FirstOrDefault();

            // Nếu không tìm thấy người dùng
            if (check == null)
            {
                // Hiển thị thông báo lỗi
                Functions._Message = "Invalid UserName or Password!";
                return RedirectToAction("Index", "Login");
            }

            // Nếu tìm thấy người dùng, lưu thông tin người dùng
            Functions._Message = string.Empty;
            Functions._UserID = check.UserID;
            Functions._UserName = string.IsNullOrEmpty(check.UserName) ? string.Empty : check.UserName;
            Functions._Email = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;

            // Chuyển hướng tới trang chính
            return RedirectToAction("Index", "Home");
        }
    }
}

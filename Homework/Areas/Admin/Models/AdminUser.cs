using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework.Areas.Admin.Models
{
    [Table("AdminUser")]
    public class AdminUser 
    {
        [Key]
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public string? PasswordHash { get; set; }
        public string? Role { get; set; }
        public string? Email { get; set; }
        public bool? IsActive { get; set; }
    }
}

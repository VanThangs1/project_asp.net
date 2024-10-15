using System.Security.Cryptography;
using System.Text;

namespace Homework.Utilities
{
    public static class Functions
    {
        

        public static int _UserID = 0;
        public static string _UserName = string.Empty;
        public static string _Email = string.Empty;
        public static string _Message = string.Empty;
        public static string _MessageEmail = string.Empty;
        // Hàm băm MD5
        public static string MD5Hash(string text)
        {
            using (MD5 md5 = MD5.Create()) // Sử dụng MD5.Create() thay cho MD5CryptoServiceProvider
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(text);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    strBuilder.Append(hashBytes[i].ToString("x2")); // Chuyển đổi sang chuỗi hex
                }
                return strBuilder.ToString();
            }
        }

        // Hàm băm mật khẩu với MD5
        public static string MD5Password(string? text)
        {
            if (string.IsNullOrEmpty(text)) // Kiểm tra xem chuỗi có rỗng không
            {
                throw new ArgumentException("Password cannot be null or empty.", nameof(text));
            }

            string str = MD5Hash(text);
            for (int i = 0; i <= 5; i++)
            {
                str = MD5Hash(str + "_" + str);
            }
            return str;
        }
        public static bool IsLogin()
        {
            if (string.IsNullOrEmpty(Functions._UserName) || string.IsNullOrEmpty(Functions._Email) || (Functions._UserID <= 0))
            {
                return false;
            }
            return true;
        }
    }
}

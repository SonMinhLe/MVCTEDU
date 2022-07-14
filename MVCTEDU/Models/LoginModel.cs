using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCTEDU.Models
{
    public class LoginModel
    {
        [Key]
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Vui lòng điền Tên Đăng Nhập!")]

        public string Username { set; get; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng điền Mật Khẩu!")]
        public string Password { set; get; }

        public bool RememberMe { set; get; }
    }
}
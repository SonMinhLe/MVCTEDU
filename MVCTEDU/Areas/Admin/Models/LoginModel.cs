using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCTEDU.Areas.Admin.Models
{
    public class LoginModel
    {
        public long ID { set; get; }

        [Required(ErrorMessage = "Vui lòng điền Tên Đăng Nhập!")]
        
        public string Username { set; get; }

        [Required(ErrorMessage = "Vui lòng điền Mật Khẩu!")]
       
        public string Password { set; get; }

        public bool RememberMe { set; get; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Models
{
    public class AccountModels
    {
        public class LogOnModel
        {
            [Required]
            [Display(Name = "邮箱")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "密码")]
            public string Password { get; set; }

            [Display(Name = "记住我?")]
            public bool RememberMe { get; set; }
        }
        public class RegisterModel
        {
            [DisplayName("登录账号")]
            [Required(ErrorMessage = "用户账号不能为空")]
            public string UserName { get; set; }

            [Required]
            [DataType(DataType.EmailAddress)]
            [Display(Name = "电子邮件地址")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "密码")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "确认密码")]
            [System.Web.Mvc.Compare("Password", ErrorMessage = "密码和确认密码不匹配。")]
            public string ConfirmPassword { get; set; }

        }
    }
}
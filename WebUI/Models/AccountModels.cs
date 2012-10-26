﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class NoteModels
    {
        public class FMNote
        {
            
            //[RegularExpression(@"^[a-z A-Z 0-9]{5,10}$", ErrorMessage = "格式错误 !")]
            [Required(ErrorMessage = "留言标题不能为空！")]
            public string PosterTitle { get; set; }

            [Required(ErrorMessage = "留言内容不能为空！")]
            [StringLength(1000, ErrorMessage = "请保持在1000个字符之内！")]
            public string Content { get; set; }

        }
        public class FMNoteHandler
        {
            [CVIntArray(ErrorMessage = "请正确选择要处理的项！")]
            public string[] IDArray { get; set; }
        }
        public class FMReply
        {
            public string StrIDS { get; set; }

            [Required(ErrorMessage = "回复不能为空！")]
            public string ReplyText { get; set; }
        }
        public class FMSearch
        {
            [Required(ErrorMessage = "请输入搜索内容")]
            public string SearchText { get; set; }

        }
    }
}
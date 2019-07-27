using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Practical_Exam_Bitmascot.Models
{
    public class LoginModel
    {
        [Key]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Email required")]
        public String Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}
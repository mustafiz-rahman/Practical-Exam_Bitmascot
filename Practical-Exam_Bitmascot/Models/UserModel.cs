using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Practical_Exam_Bitmascot.Helper;

namespace Practical_Exam_Bitmascot.Models
{
    public class UserModel
    {
        [Key]
        public int id { get; set; }

        
        [Required(AllowEmptyStrings =false,ErrorMessage ="First name required")]
        public String FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name required")]
        public String LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address required")]

        public String Address { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone required")]
        [DataType(DataType.PhoneNumber)]
        public String Phone { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email required")]
        [DataType(DataType.EmailAddress)]
        [Remote("EmailExists", "Home", HttpMethod = "POST", ErrorMessage = "Email address already registered.")]
        public String Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Date of Birth required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}
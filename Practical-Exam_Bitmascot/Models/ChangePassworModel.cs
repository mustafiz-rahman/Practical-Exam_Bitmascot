using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Practical_Exam_Bitmascot.Models
{
    public class ChangePassworModel
    {
        [Key]
        
        [Required(AllowEmptyStrings =false,ErrorMessage ="This Field Required")]
        
        [DataType(DataType.Password)]
        [DisplayName("Old Password")]
        public string OldPassword { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field Required")]
        [DataType(DataType.Password)]
        [DisplayName("New Password")]
        public string NewPassword { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessage = "This Field Required")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm New Password")]
        [Compare("NewPassword")]
        public string ConfrmNewPassword { get; set; }
        
    }
}
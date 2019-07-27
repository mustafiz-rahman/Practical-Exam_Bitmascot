using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Practical_Exam_Bitmascot.Models
{
    public class UserProfileModel
    {
       
       // [Table("SignUpInfo")]
       [DisplayName("First Name")]
        public String  FirstName { get; set; }
        [DisplayName("Last Name")]
        public String LastName { get; set; }
        [DisplayName("Address")]
        public String Address { get; set; }
        [DisplayName("Phone")]
        public String Phone { get; set; }
        [DisplayName("Email")]
        public String  Email { get; set; }
        [DisplayName("Date of Birth")]
        public DateTime Dob { get; set; }
    }
}
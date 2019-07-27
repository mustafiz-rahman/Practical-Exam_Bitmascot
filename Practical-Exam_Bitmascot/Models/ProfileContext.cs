using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Practical_Exam_Bitmascot.Models
{
    public class ProfileContext :DbContext
    {
        public DbSet<UserProfileModel> userProfileModels { get; set; }
    }
}
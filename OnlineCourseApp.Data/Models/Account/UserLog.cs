using OnlineCourse.Model.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCourseApp.Data.Models.Account
{
    public class UserLog : BaseEntity
    {
        public DateTime LoginTime { get; set; }
        public int UserID { get; set; }
        public AppUser User { get; set; }
    }
}

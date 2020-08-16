using OnlineCourse.Model.Models.BaseEntity;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCourseApp.Data.Models.Basic
{
    public class Student : BaseEntity
    {
        [Unique]
        public string StudentIDNumber { get; set; }
        public AppUser User { get; set; }
    }
}

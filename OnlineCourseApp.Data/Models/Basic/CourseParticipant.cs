using OnlineCourse.Model.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCourseApp.Data.Models.Basic
{
    public class CourseParticipant:BaseEntity
    {
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }
    }
}

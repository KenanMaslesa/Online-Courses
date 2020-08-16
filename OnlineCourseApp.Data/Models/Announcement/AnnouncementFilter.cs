using OnlineCourse.Model.Models.BaseEntity;
using OnlineCourseApp.Data.Models.Basic;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCourseApp.Data.Models.Announcement
{
    public class AnnouncementFilter: BaseEntity
    {
        public int AnnouncementID { get; set; }
        public Announcement Announcement { get; set; }

        public int? CourseTypeID { get; set; }
        public CourseType CourseType { get; set; }

        public int? CourseSectionID { get; set; }
        public CourseSection CourseSection { get; set; }

        public int? CourseID { get; set; }
        public Course Course { get; set; }
    }
}

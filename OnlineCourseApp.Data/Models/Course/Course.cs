using OnlineCourse.Model.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineCourseApp.Data.Models.Basic
{
    public class Course : BaseEntity
    {
        public string CourseName { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string Notes { get; set; }

        [ForeignKey(nameof(CourseSection))]
        public int CourseSectionID { get; set; }
        public virtual CourseSection CourseSection { get; set; }
        public bool EnableCourseSessions { get; set; }
        public bool EnableVideoRecording { get; set; }
        //public  virtual List<CourseParticipant> CourseParticipant { get; set; }

    }
}

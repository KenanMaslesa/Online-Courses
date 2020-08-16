using OnlineCourse.Model.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineCourseApp.Data.Models.Basic
{
    public class CourseSection : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(CourseType))]
        public int CourseTypeID { get; set; }
        public virtual CourseType CourseType { get; set; }

        [ForeignKey(nameof(CourseParent))]
        public int? CourseParentID { get; set; }
        public virtual CourseSection CourseParent { get; set; }
        public virtual List<Course> Courses { get; set; }
    }
}

using OnlineCourse.Model.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineCourseApp.Data.Models.Basic
{
    public class CourseType:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

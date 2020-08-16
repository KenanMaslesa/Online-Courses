using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OnlineCourseApp.Data.ViewModels
{
   public class CourseVM
    {
        public int CourseID { get; set; }
        [DisplayName("Naziv kursa")]
        public string CourseName { get; set; }
        [DisplayName("Početak")]
        public DateTime Start { get; set; }
        [DisplayName("Kraj")]
        public DateTime? End { get; set; }
        [DisplayName("Bilješka")]
        public string Notes { get; set; }
        public int CourseSectionID { get; set; }
        public string CourseSection { get; set; }
    }
}

using OnlineCourseApp.Data.Models.Basic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineCourseApp.Data.ViewModels
{
    public class CourseSectionPreviewVM
    {
        public int CourseSectionID { get; set; }
      
        [DisplayName("Oblast kursa")]
        public string Name { get; set; }

        [DisplayName("Opis")]
        public string Description { get; set; }

        [DisplayName("Tip kursa")]
        public int CourseTypeID { get; set; }
        public string CourseType { get; set; }

        [DisplayName("Glavna oblast kursa")]
        public int? CourseParentID { get; set; }
        public string CourseParent { get; set; }

        [DisplayName("Lista kurseva")]
        public virtual List<CourseVM> Courses { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineCourseApp.Data.ViewModels
{
    public class CourseEditVM
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        [DisplayName("Početak")]
        public DateTime Start { get; set; }
        [DisplayName("Kraj")]
        public DateTime? End { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        [MaxLength(50, ErrorMessage = "Maksimalan broj znakova je 50")]
        [DisplayName("Bilješka")]
        public string Notes { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        [DisplayName("Omogući sesije kursa")]
        public bool EnableCourseSessions { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        [DisplayName("Omogući video snimanje")]
        public bool EnableVideoRecording { get; set; }
    }
}

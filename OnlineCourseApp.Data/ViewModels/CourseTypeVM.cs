using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineCourseApp.Data.ViewModels
{
    public class CourseTypeVM
    {
        public int CourseTypeID { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        [MaxLength(30, ErrorMessage = "Maksimalan broj znakova je 30")]
        [DisplayName("Tip kursa")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        [DisplayName("Opis")]
        [MaxLength(100, ErrorMessage = "Maksimalan broj znakova je 100")]
        public string Description { get; set; }
    }
}

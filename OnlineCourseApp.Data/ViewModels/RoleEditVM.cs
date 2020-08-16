using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace OnlineCourseApp.Data.ViewModels
{
    public class RoleEditVM
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        public string RoleName { get; set; }
    }
}

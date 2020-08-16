using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineCourseApp.Data.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Korisničko ime je obavezno polje")]
        [Display(Name = "Korisničko ime")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lozinka je obavezno polje")]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}

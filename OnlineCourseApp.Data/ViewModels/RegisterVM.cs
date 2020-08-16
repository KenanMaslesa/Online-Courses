using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseApp.ViewModels
{
    public class RegisterVM
    {   
        [Required(ErrorMessage = "Ime je obavezno polje.")]
        [Display(Name = "Ime")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno polje.")]
        [Display(Name = "Prezime")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Korisničko ime je obavezno polje.")]
        [Display(Name = "Korisničko ime")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email je obavezno polje.")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lozinka je obavezno polje.")]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Potvrda lozinke je obavezno polje.")]
        [DataType(DataType.Password)]
        [Display(Name = "Potvrda lozinke")]
        [Compare("Password", ErrorMessage = "Lozinke nisu iste.")]
        public string ConfirmPassword { get; set; }
    }
}

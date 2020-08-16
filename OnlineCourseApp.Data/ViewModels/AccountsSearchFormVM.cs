using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineCourseApp.Data.ViewModels
{
    public class AccountsSearchFormVM
    {
        [Display(Name = "Korisničko ime")]
        public string Username { get; set; }

        [Display(Name = "Ime ili prezime")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineCourseApp.Data.Models.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineCourseApp.Data.ViewModels
{
    public class UserWM
    {
        public int UserId { get; set; }

        [Display(Name ="Korisničko ime")]
        public string Username { get; set; }

        [Display(Name = "Lozinka")]
        public string Password { get; set; }
        public string FullName { get; set; }
        public bool Admin { get; set; }
        public bool Professor { get; set; }
        public bool Student { get; set; }
        public DateTime RegistrationDate { get; set; }
        public List<UserLog> UserLog { get; set; }
    }
}

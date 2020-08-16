using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCourseApp.Data.ViewModels
{
    public class AccountsVM
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public IList<string> Permision { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
    }
}

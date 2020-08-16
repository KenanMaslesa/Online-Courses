using OnlineCourseApp.Data.DataRepository;
using OnlineCourseApp.Data.EF;
using OnlineCourseApp.Data.Models;
using OnlineCourseApp.Data.Models.Account;
using OnlineCourseApp.Data.ViewModels;
using OnlineCourseApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineCourseApp.Data.RepositoryInterfaces
{
    public interface IUserRepository : IBaseRepository<UserLog>
    {
        public List<UserLog> GetMyLastLogins(int userID);

        public List<AppUser> GetAccounts(string username, string name, string email);

    }
}

using OnlineCourseApp.Data.DataRepository.OnlineCourseApp.Data.DataRepository;
using OnlineCourseApp.Data.EF;
using OnlineCourseApp.Data.Models;
using OnlineCourseApp.Data.Models.Account;
using OnlineCourseApp.Data.RepositoryInterfaces;
using OnlineCourseApp.Data.ViewModels;
using OnlineCourseApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace OnlineCourseApp.Data.DataRepository
{
    public class UserRepository : BaseRepository<UserLog>, IUserRepository
    {
        public UserRepository(MyDBContext db) : base(db) { }

        public List<UserLog> GetMyLastLogins(int userID)
        {
            return db.UserLog.Where(x => x.UserID == userID).OrderByDescending(x => x.LoginTime).ToList();
        }
        public List<AppUser> GetAccounts(string username, string name, string email)
        {
            return db.Users.Where(x => (x.UserName == username || username == null)
                                           && (x.FirstName == name || x.LastName == name || name == null)
                                           && (x.Email == email || email == null)).ToList();
                                        
        }
    }
}


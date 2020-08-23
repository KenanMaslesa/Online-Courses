using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseApp.Data.DataRepository.IDataRepository;
using OnlineCourseApp.Data.RepositoryInterfaces;
using OnlineCourseApp.Data.ViewModels;
using OnlineCourseApp.Enums;

namespace OnlineCourseApp.Controllers
{
    public class DashboardController : BaseController
    {
        private IAnnouncementRepository _announcementRepository;
        public DashboardController(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }
        public IActionResult Home(string permission = null)
        {
            HttpContext.Session.SetString("ref", "dashboard");

            if (permission != null)
            {
                Permission = permission;
                if (User.IsInRole(permission))
                {
                    if(permission == "Admin")
                    {
                        return View($"{permission}Home", new DashboardVM { Announcements = _announcementRepository.GetLastAnnouncementsForAdmin() });

                    }
                    AnnouncementFilterType x = permission == "Student" ? AnnouncementFilterType.AllStudents : AnnouncementFilterType.AllProfessors;
                    return View($"{permission}Home", new DashboardVM { Announcements = _announcementRepository.GetLastAnnouncements(x)}); 
                }
            }
            if (User.IsInRole("Admin"))
            {
                Permission = "Admin";
                return View("AdminHome",new DashboardVM { Announcements = _announcementRepository.GetLastAnnouncementsForAdmin()});
            }

            else if (User.IsInRole("Profesor"))
            {
                Permission = "Profesor";
                return View("ProfesorHome", new DashboardVM { Announcements = _announcementRepository.GetLastAnnouncements(AnnouncementFilterType.AllProfessors) });
            }

            else if (User.IsInRole("Student"))
            {
                Permission = "Student";
                return View("StudentHome", new DashboardVM { Announcements = _announcementRepository.GetLastAnnouncements(AnnouncementFilterType.AllStudents) });
            }
            else
                return RedirectToAction("Login", "Account");
        }
    }
   
}
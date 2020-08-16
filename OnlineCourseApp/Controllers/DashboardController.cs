using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseApp.Data.RepositoryInterfaces;

namespace OnlineCourseApp.Controllers
{
    public class DashboardController : BaseController
    {
        private ICourseRepository courseRepository;
        public DashboardController(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }
        public IActionResult Home(string permission = null)
        {
            if (permission != null)
            {
                Permission = permission;
                if (User.IsInRole(permission))
                { 
                    if(permission == "Student")
                    {
                        var courses = courseRepository.GetAllCourses();
                        return View("StudentHome", courses);
                    }
                    return View($"{permission}Home"); 
                }
            }
            if (User.IsInRole("Admin"))
            {
                Permission = "Admin";
                return View("AdminHome");
            }

            else if (User.IsInRole("Profesor"))
            {
                Permission = "Profesor";
                return View("ProfesorHome");
            }

            else if (User.IsInRole("Student"))
            {
                Permission = "Student";
                var courses = courseRepository.GetAllCourses();
                return View("StudentHome", courses);
            }
            else
                return RedirectToAction("Login", "Account");
        }
    }
   
}
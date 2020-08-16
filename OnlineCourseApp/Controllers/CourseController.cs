using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseApp.Data.Models.Basic;
using OnlineCourseApp.Data.RepositoryInterfaces;
using OnlineCourseApp.Data.ViewModels;

namespace OnlineCourseApp.Controllers
{
    public class CourseController : Controller
    {
        private ICourseRepository courseRepository;
        private ICourseSectionRepository2 courseSectionRepository2;

        public CourseController(ICourseRepository courseRepository, ICourseSectionRepository2 courseSectionRepository2)
        {
            this.courseRepository = courseRepository;
            this.courseSectionRepository2 = courseSectionRepository2;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Prikaz(int courseSectionID)
        {
            var courses = courseRepository.GetCoursesBasedOnSection(courseSectionID);
            return View(courses);
        }
        public IActionResult CourseApplications()
        {
            var courses = courseRepository.GetAllCourses();
            return View(courses);
        }
        public IActionResult DodajForma()
        {

            ViewData["courseSections"] = courseSectionRepository2.GetCourseSectionList();
            CourseAddVM Model = new CourseAddVM();
            return PartialView(Model);

        }
        public IActionResult Dodaj(CourseAddVM c)
        {
            Course course = new Course
            {
                CourseName =c.CourseName,
                Start =c.Start,
                End = c.End,
                Notes= c.Notes,
                CourseSectionID = c.CourseSectionID,  
                EnableCourseSessions = c.EnableCourseSessions,
                EnableVideoRecording = c.EnableVideoRecording

    };
            courseRepository.Add(course);

            return Redirect("/Course/Prikaz");
        }

    
        public IActionResult EditCourse(int courseID)
        {
            var course = courseRepository.EditCourse(courseID);

            if (course == null)
            {
                ViewBag.ErrorMessage = "Kurs nije pronađen";
                return View("_NotFound");
            }
           
            return PartialView(course);
        }
        public IActionResult EditCourse(CourseEditVM c)
        {
            var course = courseRepository.EditCourse(c.CourseID);
            if (course == null)
            {
                ViewBag.ErrorMessage = "Kurs nije pronađen";
                return View("_NotFound");
            }
            else
            {
                course.CourseName = c.CourseName;
                course.Start = c.Start;
                course.End = c.End;
                course.Notes = c.Notes;
                course.EnableCourseSessions = c.EnableCourseSessions;
                course.EnableVideoRecording = c.EnableVideoRecording; 
            }

            return RedirectToAction("Prikaz", "Course");
        }


        public IActionResult Obrisi(int CourseID)
        {
            courseRepository.Delete(CourseID);
            return Redirect(url: "/Course/Prikaz");
        }

    }
}
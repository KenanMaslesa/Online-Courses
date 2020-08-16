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
    public class CourseTypeController : Controller
    {
        private ICourseTypeRepository courseTypeRepository;
        public CourseTypeController(ICourseTypeRepository courseTypeRepository)
        { this.courseTypeRepository = courseTypeRepository; }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DodajForma()
        {
            CourseTypeVM Model = new CourseTypeVM();
            return PartialView(Model);

        }
        public IActionResult Dodaj(CourseTypeVM ct)
        {
            CourseType courseType = new CourseType
            {
                Name=ct.Name,
                Description = ct.Description
            };
            courseTypeRepository.Add(courseType);

            return Redirect("/CourseType/Prikaz");
        }

        public IActionResult Prikaz()
        {
            var courseTypes = courseTypeRepository.GetAllCourseTypes();
            return View(courseTypes);
        }

        public IActionResult Obrisi(int courseTypeID)
        {
            courseTypeRepository.Delete(courseTypeID);

            return Redirect(url: "/CourseType/Prikaz");
        }
    }
}
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
    public class CourseSectionController : Controller
    {
        private ICourseSectionRepository courseSectionRepository;
        private ICourseSectionRepository2 courseSectionRepository2;
        private ICourseTypeRepository courseTypeRepository;
        private ICourseTypeRepository2 courseTypeRepository2;
        public CourseSectionController(ICourseSectionRepository courseSectionRepository,
                                      ICourseSectionRepository2 courseSectionRepository2,
                                      ICourseTypeRepository courseTypeRepository,
                                      ICourseTypeRepository2 courseTypeRepository2)
        {
            this.courseSectionRepository = courseSectionRepository;
            this.courseSectionRepository2 = courseSectionRepository2;
            this.courseTypeRepository = courseTypeRepository;
            this.courseTypeRepository2 = courseTypeRepository2;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DodajForma()
        {

            ViewData["courseType"] = courseTypeRepository2.GetCourseTypeList();
            ViewData["courseParent"] = courseSectionRepository2.GetCourseSectionList();
            CourseSectionAddVM Model = new CourseSectionAddVM();
            return PartialView(Model);

        }
        public IActionResult Dodaj(CourseSectionAddVM cs)
        {
            CourseSection courseSection = new CourseSection
            {
                Name=cs.Name,
                Description = cs.Description,
                CourseTypeID = cs.CourseTypeID,
                CourseParentID=cs.CourseParentID

            };
            courseSectionRepository.Add(courseSection);

            return Redirect("/CourseSection/Prikaz");
        }
        public IActionResult Prikaz()
        {
            var cs = courseSectionRepository.GetAllCourseSections();
            return View(cs);
        }

        public IActionResult Obrisi(int CourseSectionID)
        {
            courseSectionRepository.Delete(CourseSectionID);
            return Redirect(url: "/CourseSection/Prikaz");
        }
    }
}
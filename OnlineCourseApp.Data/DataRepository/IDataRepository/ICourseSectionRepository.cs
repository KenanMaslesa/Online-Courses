using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineCourseApp.Data.DataRepository;
using OnlineCourseApp.Data.EF;
using OnlineCourseApp.Data.Models;
using OnlineCourseApp.Data.Models.Basic;
using OnlineCourseApp.Data.ViewModels;
using OnlineCourseApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCourseApp.Data.RepositoryInterfaces
{
    public interface ICourseSectionRepository : IBaseRepository<CourseSection>
    {
        public List<CourseSectionPreviewVM> GetAllCourseSections();

    }
    public interface ICourseSectionRepository2 : IBaseRepository<CourseSection>
    {
        public List<SelectListItem> GetCourseSectionList();

    }
}

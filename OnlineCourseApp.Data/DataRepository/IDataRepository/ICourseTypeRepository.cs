using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineCourseApp.Data.DataRepository;
using OnlineCourseApp.Data.Models.Basic;
using OnlineCourseApp.Data.ViewModels;
using System;
using System.Collections.Generic;


namespace OnlineCourseApp.Data.RepositoryInterfaces
{
    public interface ICourseTypeRepository : IBaseRepository<CourseType>
    {
        public List<CourseTypeVM> GetAllCourseTypes();
    }
    public interface ICourseTypeRepository2 : IBaseRepository<CourseType>
    {
        public List<SelectListItem> GetCourseTypeList();
    }
}

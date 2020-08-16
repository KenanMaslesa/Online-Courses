using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineCourseApp.Data.DataRepository.OnlineCourseApp.Data.DataRepository;
using OnlineCourseApp.Data.EF;
using OnlineCourseApp.Data.Models.Basic;
using OnlineCourseApp.Data.RepositoryInterfaces;
using OnlineCourseApp.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineCourseApp.Data.DataRepository
{
    public class CourseTypeRepository : BaseRepository<CourseType>, ICourseTypeRepository, ICourseTypeRepository2
    {
        public CourseTypeRepository(MyDBContext db) : base(db) { }

        public List<CourseTypeVM> GetAllCourseTypes()
        {
            return db.CourseType.Select(ct => new CourseTypeVM
            {
                CourseTypeID = ct.ID,
                Name = ct.Name,
                Description = ct.Description
            }).ToList();
        }

        public List<SelectListItem> GetCourseTypeList()
        {
            return db.CourseType.Select(ct => new SelectListItem
            {
                Value = ct.ID.ToString(),
                Text = ct.Name
            }).ToList();
        }
    }
}

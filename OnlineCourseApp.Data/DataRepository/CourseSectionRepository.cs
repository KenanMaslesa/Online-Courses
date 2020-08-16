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
    public class CourseSectionRepository : BaseRepository<CourseSection>, ICourseSectionRepository, ICourseSectionRepository2
    {
        public CourseSectionRepository(MyDBContext db) : base(db) { }

        public List<CourseSectionPreviewVM> GetAllCourseSections()
        {
            return db.CourseSection.Select(cs => new CourseSectionPreviewVM
            {
                CourseSectionID=cs.ID,
                Name=cs.Name,
                Description=cs.Description,
                CourseType=cs.CourseType.Name,
                CourseParent=cs.CourseParent.Name,
                Courses=cs.Courses.Where(c=>c.CourseSectionID==cs.ID).Select(course => new CourseVM
                {
                    CourseID = course.ID,
                    CourseName = course.CourseName,
                    Start = course.Start,
                    End = course.End,
                    Notes = course.Notes,
                    CourseSectionID = course.CourseSectionID
                }).ToList()

        }).ToList();
        }
        public List<SelectListItem> GetCourseSectionList()
        {
            return db.CourseSection.Select(cs => new SelectListItem
            {
                Value = cs.ID.ToString(),
                Text = cs.Name
            }).ToList();
        }


    }

}

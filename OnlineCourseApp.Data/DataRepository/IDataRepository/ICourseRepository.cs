using OnlineCourseApp.Data.DataRepository;
using OnlineCourseApp.Data.Models.Basic;
using OnlineCourseApp.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCourseApp.Data.RepositoryInterfaces
{
    public interface ICourseRepository : IBaseRepository<Course>
    {
        public List<CourseVM> GetAllCourses();
        public List<CourseVM> GetCoursesBasedOnSection(int courseSectionID);
        public CourseEditVM EditCourse(int courseID);
    }

}

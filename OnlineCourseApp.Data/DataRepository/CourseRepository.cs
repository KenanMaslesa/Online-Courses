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
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(MyDBContext db) : base(db) { }

        public List<CourseVM> GetAllCourses()
        {
            return db.Course.Select(course => new CourseVM
            {
                CourseID = course.ID,
                CourseName = course.CourseName,
                Start = course.Start,
                End = course.End,
                Notes = course.Notes,
                CourseSectionID=course.CourseSectionID,
                CourseSection=course.CourseSection.Name
            }).ToList();
        }

        public List<CourseVM> GetCoursesBasedOnSection(int courseSectionID)
        {
            return db.Course.Where(c => c.CourseSectionID == courseSectionID).Select(course => new CourseVM
            {
                CourseID = course.ID,
                CourseName = course.CourseName,
                Start = course.Start,
                End = course.End,
                Notes = course.Notes,
                CourseSectionID = course.CourseSectionID
            }).ToList();
        }

        public CourseEditVM EditCourse(int courseID)
        {
            Course course = db.Course.Find(courseID);

            if (course == null)
                return null;

            else return new CourseEditVM
            {
                CourseID = course.ID,
                CourseName = course.CourseName,
                Start = course.Start,
                End = course.End,
                Notes = course.Notes,
                EnableCourseSessions = course.EnableCourseSessions,
                EnableVideoRecording = course.EnableVideoRecording
            };
        }
    }
}

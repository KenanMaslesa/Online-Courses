using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineCourseApp.Data.Models;
using OnlineCourseApp.Data.Models.Basic;
using OnlineCourseApp.Data.Models.Account;
using OnlineCourseApp.Data.Models.Announcement;

namespace OnlineCourseApp.Data.EF
{
    public partial class MyDBContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        { } 
        public DbSet<Region> Region { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<CourseType> CourseType { get; set; }
        public DbSet<CourseSection> CourseSection { get; set; }
        public DbSet<UserLog> UserLog { get; set; }
        public DbSet<Announcement> Announcement { get; set; }
        public DbSet<AnnouncementFilter> AnnouncementFilter { get; set; }

    }
}

using OnlineCourse.Model.Models.BaseEntity;
using OnlineCourseApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace OnlineCourseApp.Data.Models.Announcement
{
    public class Announcement: BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public int AnnouncementOwnerID { get; set; }
        public virtual AppUser AnnouncementOwner { get; set; }

        public AnnouncementFilterType FilterType { get; set; }

        public string PostOwner { get; set; }

        public DateTime RecordCreated { get; set; }

        public virtual List<AnnouncementFilter> AnnouncementFilters { get; set; }

    }
}

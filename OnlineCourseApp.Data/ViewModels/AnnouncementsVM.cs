using ImTools;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineCourseApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineCourseApp.Data.ViewModels
{
    public class AnnouncementsVM
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public int AnnouncementOwnerID { get; set; }

        public string PostOwner { get; set; }
        public DateTime RecordCreated { get; set; }
        public AnnouncementFilterType AnnouncementFilter { get; set; }

    }
}

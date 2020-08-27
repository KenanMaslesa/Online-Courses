using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineCourseApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OnlineCourseApp.Data.ViewModels
{
    public class AnnouncementNewVM
    {
        public int ID { get; set; }

        [DisplayName("Naslov")]
        public string Title { get; set; }

        [DisplayName("Kratak opis")]
        public string ShortDescription { get; set; }

        [DisplayName("Sadržaj")]
        public string Description { get; set; }

        public int AnnouncementFilterID { get; set; }

        public List<SelectListItem> AnnouncementFilter { get; set; }

    }
}

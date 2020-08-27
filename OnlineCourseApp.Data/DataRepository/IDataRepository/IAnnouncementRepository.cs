using OnlineCourseApp.Data.Models.Announcement;
using OnlineCourseApp.Data.ViewModels;
using OnlineCourseApp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCourseApp.Data.DataRepository.IDataRepository
{
    public interface IAnnouncementRepository : IBaseRepository<Announcement>
    {
        public List<AnnouncementsVM> GetAllAnnouncements(AnnouncementFilterType? permission = null);

        public List<AnnouncementsVM> GetAllAnnouncementsForProfessor(int userID);

        public List<AnnouncementsVM> GetLastAnnouncements(AnnouncementFilterType permission);
        public List<AnnouncementsVM> GetLastAnnouncementsForAdmin();

    }
}

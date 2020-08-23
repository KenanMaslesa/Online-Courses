using OnlineCourseApp.Data.DataRepository.IDataRepository;
using OnlineCourseApp.Data.DataRepository.OnlineCourseApp.Data.DataRepository;
using OnlineCourseApp.Data.EF;
using OnlineCourseApp.Data.Models.Announcement;
using OnlineCourseApp.Data.RepositoryInterfaces;
using OnlineCourseApp.Data.ViewModels;
using OnlineCourseApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineCourseApp.Data.DataRepository
{
    public class AnnouncementRepository : BaseRepository<Announcement>, IAnnouncementRepository
    {
        public AnnouncementRepository(MyDBContext db) : base(db)
        {

        }
        public List<AnnouncementsVM> GetAllAnnouncements(AnnouncementFilterType? permission = null)
        {
            return db.Announcement.Select(x => new AnnouncementsVM
            {
                ID = x.ID,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                PostOwner = x.PostOwner,
                Description = x.Description,
                AnnouncementOwnerID = x.AnnouncementOwnerID,
                AnnouncementFilter = x.FilterType,
                RecordCreated = x.RecordCreated
            }).Where(x => x.AnnouncementFilter == permission ||
                          x.AnnouncementFilter == AnnouncementFilterType.All || 
                          x.AnnouncementFilter == AnnouncementFilterType.AllWithWebsite ||
                          permission == null).OrderByDescending(x => x.RecordCreated).ToList();
        }
        public List<AnnouncementsVM> GetAllAnnouncementsForProfessor(int userID)
        {
            return db.Announcement.Select(x => new AnnouncementsVM
            {
                ID = x.ID,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                PostOwner = x.PostOwner,
                Description = x.Description,
                AnnouncementOwnerID = x.AnnouncementOwnerID,
                AnnouncementFilter = x.FilterType,
                RecordCreated = x.RecordCreated
            }).Where(x => x.AnnouncementOwnerID == userID).OrderByDescending(x => x.RecordCreated).ToList();
        }

        public List<AnnouncementsVM> GetLastAnnouncements(AnnouncementFilterType permission)
        {
            return db.Announcement.Select(x => new AnnouncementsVM
            {
                ID = x.ID,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                AnnouncementFilter = x.FilterType,
                Description = x.Description,
                PostOwner = x.PostOwner,
                RecordCreated = x.RecordCreated,
                AnnouncementOwnerID = x.AnnouncementOwnerID
            }).Where(x => x.AnnouncementFilter == AnnouncementFilterType.All ||
                          x.AnnouncementFilter == AnnouncementFilterType.AllWithWebsite ||
                          x.AnnouncementFilter == permission).OrderByDescending(x => x.RecordCreated).Take(5).ToList();
        }
        public List<AnnouncementsVM> GetLastAnnouncementsForAdmin()
        {
            return db.Announcement.Select(x => new AnnouncementsVM
            {
                ID = x.ID,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                AnnouncementFilter = x.FilterType,
                Description = x.Description,
                PostOwner = x.PostOwner,
                RecordCreated = x.RecordCreated,
                AnnouncementOwnerID = x.AnnouncementOwnerID
            }).OrderByDescending(x => x.RecordCreated).Take(5).ToList();
        }


    }
}

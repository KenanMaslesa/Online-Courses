using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineCourseApp.Data.DataRepository.IDataRepository;
using OnlineCourseApp.Data.Models;
using OnlineCourseApp.Data.Models.Announcement;
using OnlineCourseApp.Data.RepositoryInterfaces;
using OnlineCourseApp.Data.ViewModels;
using OnlineCourseApp.Enums;

namespace OnlineCourseApp.Controllers
{
    public class AnnouncementController : BaseController
    {
        private IAnnouncementRepository _announcementRepository;
        private readonly UserManager<AppUser> _userManager;

        public AnnouncementController(IAnnouncementRepository announcementRepository,
                                       UserManager<AppUser> userManager)
        {
            _announcementRepository = announcementRepository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            Ref = "Index";

            if (Permission=="Profesor")
            {
                return RedirectToAction("AnnouncementsForProfessors");
            }
            else if(Permission == "Student")
            {
                return RedirectToAction("AnnouncementsForStudents");

            }
            List<AnnouncementsVM> announcements = _announcementRepository.GetAllAnnouncements();
            return View(announcements);
        }

        [Authorize(Roles = "Admin, Student")]

        public IActionResult AnnouncementsForStudents()
        {
            Ref = "AnnouncementsForStudents";
            List<AnnouncementsVM> announcements = _announcementRepository.GetAllAnnouncements(AnnouncementFilterType.AllStudents);
            return View(announcements);
        }

        [Authorize(Roles = "Admin, Profesor")]

        public async Task<IActionResult> AnnouncementsForProfessors()
        {
            Ref = "AnnouncementsForProfessors";
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            List<AnnouncementsVM> announcements = _announcementRepository.GetAllAnnouncementsForProfessor(user.Id);
            return View(announcements);
        }

        [Authorize(Roles = "Admin, Profesor")]

        public IActionResult New()
        {
            AnnouncementNewVM model = new AnnouncementNewVM()
            {
                AnnouncementFilter = new List<SelectListItem>()
            };
            model.AnnouncementFilter.Add(new SelectListItem { Text = "Svi korisnici", Value = ((int)AnnouncementFilterType.All).ToString() });
            model.AnnouncementFilter.Add(new SelectListItem { Text = "Svi korisnici i websajt", Value = ((int)AnnouncementFilterType.AllWithWebsite).ToString() });
            model.AnnouncementFilter.Add(new SelectListItem { Text = "Svi profesori", Value = ((int)AnnouncementFilterType.AllProfessors).ToString() });
            model.AnnouncementFilter.Add(new SelectListItem { Text = "Svi studenti", Value = ((int)AnnouncementFilterType.AllStudents).ToString() });
           
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> New(AnnouncementNewVM vm)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            Announcement announcement = new Announcement
            {
                Title = vm.Title,
                Description = vm.Description,
                ShortDescription = vm.ShortDescription,
                FilterType = (AnnouncementFilterType)vm.AnnouncementFilterID,
                RecordCreated = DateTime.Now,
                PostOwner = user.FirstName + " " + user.LastName,
                AnnouncementOwnerID = user.Id,
            };
            _announcementRepository.Add(announcement);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin, Profesor")]

        public IActionResult Details(int announcementID)
        {
            Announcement x = _announcementRepository.GetById(announcementID);
            AnnouncementsVM model = new AnnouncementsVM
            {
                ID = x.ID,
                AnnouncementOwnerID = x.AnnouncementOwnerID,
                AnnouncementFilter = x.FilterType,
                PostOwner = x.PostOwner,
                RecordCreated = x.RecordCreated,
                Description = x.Description,
                ShortDescription = x.ShortDescription,
                Title = x.Title,
            };
            return View(model);
        }

        [Authorize(Roles = "Admin, Profesor")]

        public IActionResult Delete(int announcementID)
        {
            _announcementRepository.Delete(announcementID);
            return RedirectToAction("Index");
        }
    }
}
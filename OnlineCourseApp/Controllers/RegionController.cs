using Microsoft.AspNetCore.Mvc;
using OnlineCourseApp.Data.Models;
using OnlineCourseApp.Data.RepositoryInterfaces;

namespace OnlineCourseApp.Controllers
{
    public class RegionController : Controller
    {
        private IRegionRepository regionRepository;
        public RegionController(IRegionRepository regionRepository)
        { this.regionRepository = regionRepository; }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DodajForma()
        {
            return PartialView();

        }
        public IActionResult Dodaj(string description)
        {
            var region = new Region
            {
                Description = description
            };
            regionRepository.Add(region);

            return Redirect("/Region/Prikaz");
        }

        public IActionResult Prikaz()
        {
            var regije = regionRepository.GetAllRegions();
            return View(regije);
        }

        public IActionResult Obrisi(int regionID)
        {
            regionRepository.Delete(regionID);
 
            return Redirect(url: "/Region/Prikaz");
        }
    }
}
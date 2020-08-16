using Microsoft.AspNetCore.Mvc;
using OnlineCourseApp.Data.Models;
using OnlineCourseApp.Data.RepositoryInterfaces;
using OnlineCourseApp.ViewModels;

namespace OnlineCourseApp.Controllers
{
    public class CityController : Controller
    {
        private ICityRepository cityRepository;
        private IRegionRepository regionRepository;
        public CityController(ICityRepository cityRepository, 
                                      IRegionRepository regionRepository)
        {
            this.cityRepository = cityRepository;
            this.regionRepository = regionRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DodajForma()
        {
            ViewData["regije"] = regionRepository.GetAllRegions();
            CityVM Model = new CityVM();
            return PartialView(Model);

        }
        public IActionResult Dodaj(CityVM m)
        {
            City city = new City
            {
                Description = m.Description,
                RegionID = m.RegionID,
                ZipCode = m.ZipCode
            };
            cityRepository.Add(city);

            return Redirect("/City/Prikaz");
        }

        public IActionResult Prikaz()
        {
            var m = cityRepository.GetAllCities();
            return View(m);
        }

        public IActionResult Obrisi(int cityID)
        {
            cityRepository.Delete(cityID);
            return Redirect(url: "/City/Prikaz");
        }
    }
}
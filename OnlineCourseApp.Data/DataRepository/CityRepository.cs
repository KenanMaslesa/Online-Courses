using OnlineCourseApp.Data.DataRepository.OnlineCourseApp.Data.DataRepository;
using OnlineCourseApp.Data.EF;
using OnlineCourseApp.Data.Models;
using OnlineCourseApp.Data.RepositoryInterfaces;
using OnlineCourseApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineCourseApp.Data.DataRepository
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(MyDBContext db) : base(db) { }

        public List<CityVM> GetAllCities()
        {
            return db.City.Select(o => new CityVM
            {
                CityID = o.ID,
                Description = o.Description,
                Region = o.Region.Description,
                ZipCode = o.ZipCode
            }).ToList();
        }
    }
}


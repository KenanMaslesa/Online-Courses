using OnlineCourseApp.Data.DataRepository;
using OnlineCourseApp.Data.EF;
using OnlineCourseApp.Data.Models;
using OnlineCourseApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCourseApp.Data.RepositoryInterfaces
{
    public interface ICityRepository : IBaseRepository<City>
    {
        public List<CityVM> GetAllCities();


    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineCourseApp.Data.DataRepository;
using OnlineCourseApp.Data.Models;
using OnlineCourseApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseApp.Data.RepositoryInterfaces
{
    public interface IRegionRepository : IBaseRepository<Region>
    {
        public List<SelectListItem> GetAllRegions();
    }
}

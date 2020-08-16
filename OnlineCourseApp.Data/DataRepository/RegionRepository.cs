using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineCourseApp.Data.DataRepository.OnlineCourseApp.Data.DataRepository;
using OnlineCourseApp.Data.EF;
using OnlineCourseApp.Data.Models;
using OnlineCourseApp.Data.RepositoryInterfaces;
using OnlineCourseApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseApp.Data.DataRepository
{
    public class RegionRepository : BaseRepository<Region>, IRegionRepository
    {
        public RegionRepository(MyDBContext context) : base(context) { }

        public List<SelectListItem> GetAllRegions()
        {
            return db.Region.Select(r => new SelectListItem
            {
                Value = r.ID.ToString(),
                Text = r.Description
            }).ToList();
        }
    }
}

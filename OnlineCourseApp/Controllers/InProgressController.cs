using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OnlineCourseApp.Controllers
{
    public class InProgressController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
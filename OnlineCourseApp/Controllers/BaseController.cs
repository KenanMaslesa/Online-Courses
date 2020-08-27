using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineCourseApp.Controllers
{
    public class BaseController : Controller
    {
        protected string SuccessMessage
        {
            get { return  TempData["SuccessMessage"] as string; }
            set { TempData["SuccessMessage"] = value; }
        }

        protected string ErrorMessage
        {
            get { return TempData["ErrorMessage"] as string; }
            set { TempData["ErrorMessage"] = value; }
        }

        protected string WarningMessage
        {
            get { return TempData["WarningMessage"] as string; }
            set { TempData["WarningMessage"] = value; }
        }

        protected string Permission
        {
            get { return HttpContext.Session.GetString("permission"); }
            set { HttpContext.Session.SetString("permission", value); }
        }

        protected string Ref
        {
            get { return HttpContext.Session.GetString("ref"); }
            set { HttpContext.Session.SetString("ref", value); }
        }


    }
}
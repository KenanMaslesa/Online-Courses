using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace OnlineCourseApp.Enums
{

    public enum AnnouncementFilterType
    {
        [Display(Name = "Svi korisnici")]
        All = 1,

        [Display(Name = "Svi korisnici i websajt")]
        AllWithWebsite = 2,

        [Display(Name = "Svi profesori")]
        AllProfessors = 3,

        [Display(Name = "Svi studenti")]
        AllStudents = 4,

        [Display(Name = "Filter po tipovima")]
        FilterByType = 5,

        [Display(Name = "Filter po sekcijama")]
        FilterBySection = 6,

        [Display(Name = "Filter po kursevima")]
        FilterByCourse = 7
    }

}

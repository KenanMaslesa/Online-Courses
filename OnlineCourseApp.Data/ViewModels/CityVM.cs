using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseApp.ViewModels
{
    public class CityVM
    {
        public int CityID { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        [DisplayName("Naziv opštine")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public int RegionID { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        [DisplayName("Poštanski broj")]
        public string ZipCode { get; set; }
    }
}

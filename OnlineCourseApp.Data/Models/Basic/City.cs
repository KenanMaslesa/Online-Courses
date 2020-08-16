using OnlineCourse.Model.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineCourseApp.Data.Models
{
    public class City : BaseEntity
    {      
        public string Description { get; set; }       
        public int RegionID { get; set; }
        public Region Region { get; set; }      
        public string ZipCode { get; set; }

    }
}

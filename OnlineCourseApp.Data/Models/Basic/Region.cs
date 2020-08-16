using OnlineCourse.Model.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineCourseApp.Data.Models
{
    public class Region : BaseEntity
    {
        public string Description { get; set; }
    }
}

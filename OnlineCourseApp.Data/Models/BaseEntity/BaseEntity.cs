using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCourse.Model.Models.BaseEntity
{
    public abstract class BaseEntity : IEntity
    {    
        public int ID { get; set; }

        public DateTime RecordUpdated { get; set; }
    }
}

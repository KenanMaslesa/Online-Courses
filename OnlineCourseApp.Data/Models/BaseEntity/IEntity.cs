using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCourse.Model.Models.BaseEntity
{
    public interface IEntity
    {
        public int ID { get; set; }

        public DateTime RecordUpdated { get; set; }
    }
}

using OnlineCourse.Model.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCourseApp.Data.DataRepository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int? id);
    }
}

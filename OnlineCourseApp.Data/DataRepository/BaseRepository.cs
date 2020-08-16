namespace OnlineCourseApp.Data.DataRepository
{
    using global::OnlineCourseApp.Data.EF;
    using Microsoft.EntityFrameworkCore;
    using OnlineCourse.Model.Models.BaseEntity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    namespace OnlineCourseApp.Data.DataRepository
    {
        public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
        {
            protected readonly MyDBContext db;
            private DbSet<T> entities;
            public BaseRepository(MyDBContext db)
            {
                this.db = db;
                entities = db.Set<T>();
            }
            public IEnumerable<T> GetAll()
            {
                return entities.AsEnumerable();
            }
            public T GetById(int id)
            {
                return entities.SingleOrDefault(s => s.ID == id);
            }
            public void Add(T entity)
            {
                if (entity == null) throw new ArgumentNullException("entity");

                entities.Add(entity);
                db.SaveChanges();
            }
            public void Update(T entity)
            {
                if (entity == null) throw new ArgumentNullException("entity");
                db.SaveChanges();
            }
            public void Delete(int? id)
            {
                if (id == null) throw new ArgumentNullException("entity");

                T entity = entities.SingleOrDefault(s => s.ID == id);
                entities.Remove(entity);
                db.SaveChanges();
            }
        }
    }
}

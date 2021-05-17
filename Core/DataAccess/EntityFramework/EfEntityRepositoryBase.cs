
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext>: IEntityRepository<TEntity>
        where TEntity: class, IEntity, new()
        where TContext:  DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext content = new TContext())
            {
                var addedEntity = content.Entry(entity);
                addedEntity.State = EntityState.Added;
                content.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext content = new TContext())
            {
                var deletedEntity = content.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                content.SaveChanges();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext content = new TContext())
            {
                return filter == null ? content.Set<TEntity>().ToList() : content.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext content = new TContext())
            {
                return content.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext content = new TContext())
            {
                var updatedEntity = content.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                content.SaveChanges();
            }
        }
    }
}

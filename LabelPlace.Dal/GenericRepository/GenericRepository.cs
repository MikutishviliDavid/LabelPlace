using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LabelPlace.Dal.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        private readonly LabelPlaceContext _context;
        private readonly DbSet<TEntity> _entities;

        public GenericRepository(LabelPlaceContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _entities;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetById(object id)
        {
            return _entities.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            _entities.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _entities.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _entities.Attach(entityToDelete);
            }

            _entities.Remove(entityToDelete);
        }

        public void Update(TEntity entityToUpdate)
        {
            _entities.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}

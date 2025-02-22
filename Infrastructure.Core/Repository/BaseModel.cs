using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Core.Context;
using Infrastructure.Core.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Core.Repository
{
    public class BaseModel<TEntity> : IBaseModel<TEntity> where TEntity : class
    {
        ContextSQL _context;
        protected DbSet<TEntity> _dbSet;

        public BaseModel(ContextSQL context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public TEntity FindById(object id)
        {
            return _dbSet.Find(id);
        }

        public TEntity Create(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity editedEntity, TEntity originalEntity, out bool changed)
        {
            _context.Entry(originalEntity).CurrentValues.SetValues(editedEntity);
            changed = _context.Entry(originalEntity).State == EntityState.Modified;
            _context.SaveChanges();
            return originalEntity;
        }

        public TEntity Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

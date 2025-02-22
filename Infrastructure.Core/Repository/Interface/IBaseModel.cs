using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Repository.Interface
{
    public interface IBaseModel<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();
        TEntity FindById(object id);
        TEntity Create(TEntity entity);
        TEntity Update(TEntity editedEntity, TEntity originalEntity, out bool changed);
        TEntity Delete(TEntity entity);
        void SaveChanges();
    }
}

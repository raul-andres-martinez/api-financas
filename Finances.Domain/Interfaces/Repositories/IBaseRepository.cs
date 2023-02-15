using Finances.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity entity);
        void Update (TEntity entity);
        void Delete(TEntity entity);
        Task<IEnumerable<TEntity>> SelectAsync(Expression<Func<TEntity, bool>>where);
        Task<TEntity> SelectAsync(int id);
    }
}

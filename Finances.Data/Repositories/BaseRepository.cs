using Finances.Data.Context;
using Finances.Domain.Entities;
using Finances.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> SelectAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> SelectAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

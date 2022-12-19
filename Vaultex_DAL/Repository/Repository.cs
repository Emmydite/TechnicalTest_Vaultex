using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vaultex_DAL.DBContext;

namespace Vaultex_DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal VaultexDBContext _dbContext;
        internal DbSet<TEntity> _entities;
        public Repository(VaultexDBContext context)
        {
            _dbContext = context;
            _entities = _dbContext.Set<TEntity>();
        }

        public bool Add(TEntity entity)
        {
            _entities.Add(entity);

            return _dbContext.SaveChanges() > 0;
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _entities.FirstOrDefault(filter);
        }
        public TEntity GetById(int id)
        {
            return _entities.Find(id);
        }
        public IQueryable<TEntity> GetAll()
        {
            return _entities.AsQueryable<TEntity>();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            return _entities.Where(filter).AsQueryable<TEntity>();
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            return await Task.FromResult(_entities.AsQueryable<TEntity>());
        }

        public async Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Task.FromResult(_entities.Where(filter).AsQueryable<TEntity>());
        }


    }
}

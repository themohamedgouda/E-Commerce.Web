using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using PrecedencesLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecedencesLayer.Repositories
{
    public class GenericRepository<TEntity, TKey>(StoredDbContext _dbContext) : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbContext.Set<TEntity>().ToListAsync();
        public async Task<TEntity?> GetByIdAsync(int id) => await _dbContext.Set<TEntity>().FindAsync(id);
        public async Task AddAsync(TEntity entity) => await _dbContext.Set<TEntity>().AddAsync(entity);
        public void Update(TEntity entity) => _dbContext.Set<TEntity>().Update(entity);
        public void Remove(TEntity entity) => _dbContext.Set<TEntity>().Remove(entity);
    }
}

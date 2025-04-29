using DomainLayer.Contracts;
using DomainLayer.Models;
using PrecedencesLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecedencesLayer.Repositories
{
    public class UnitOfWork(StoredDbContext _dbContext) : IUnitOfWork
    {
        private readonly Dictionary<string , object> _Repository = [];
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var typeName = typeof(TEntity).Name;
            //if (!_Repository.ContainsKey(typeName))
            if (_Repository.TryGetValue(typeName,out object? value))
            {
                
            //return (IGenericRepository<TEntity, TKey>)_Repository[typeName];
            return (IGenericRepository<TEntity, TKey>)value;
            }
            
            else
            {
                var Repo = new GenericRepository<TEntity, TKey>(_dbContext);
                _Repository.Add(typeName, Repo);
                // _Repository[typeName] = Repo;
                return Repo;
            }
           
        }
        public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
        
    }
}

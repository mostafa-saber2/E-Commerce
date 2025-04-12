using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;
using Domain.Repositories;
using Persistance.Data;

namespace Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _storeContext;
        private readonly ConcurrentDictionary<string, object> _Repositories;
        public UnitOfWork(StoreContext storeContext)
        {
            _storeContext = storeContext;
            _Repositories = new();
        }
        public IGenericRepos<TEntity, TKey> GetRepos<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            //var TyoeName = typeof(TEntity).Name;
            //if (_Repositories.ContainsKey(TyoeName))
            //    return (IGenericRepos<TEntity, TKey>)_Repositories[TyoeName];
            //var Repo = new GenericRepos<TEntity, TKey>(_storeContext);
            //_Repositories.GetOrAdd(TyoeName, Repo);
            //return Repo;
            return(IGenericRepos<TEntity,TKey>)_Repositories.GetOrAdd(typeof(TEntity).Name, _ => new GenericRepos<TEntity, TKey>(_storeContext));
        }

        public async Task<int> SaveChangesAsync()
      => await _storeContext.SaveChangesAsync();
    }
}

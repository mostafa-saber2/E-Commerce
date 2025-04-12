using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;

namespace Domain.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _storeContext;

        public UnitOfWork(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public IGenericRepos<TEntity, TKey> GetRepos<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveChangesAsync()
        {
           await _storeContext.SaveChangesAsync();
            return await _storeContext.SaveChangesAsync();
        }
    }
}

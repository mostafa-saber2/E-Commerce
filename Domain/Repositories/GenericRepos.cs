using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Domain.Repositories
{
    public class GenericRepos<TEntity, Tkey> : IGenericRepos<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        private readonly StoreContext _storeContext;

        public GenericRepos(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task AddAsync(TEntity entity)
           => await _storeContext.Set<TEntity>().AddAsync(entity);


        public void DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync(bool TrackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity?> GetByIdAsync(Tkey id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        Task IGenericRepos<TEntity, Tkey>.UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }

  
}

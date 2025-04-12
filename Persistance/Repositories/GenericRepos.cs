using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Data;


namespace Domain.Repositories
{
    public class GenericRepos<TEntity, Tkey> : IGenericRepos<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        private readonly Persistance.Data.AppContext _storeContext;

        public GenericRepos(Persistance.Data.AppContext storeContext)
        {
           _storeContext = storeContext;
        }
        public async Task AddAsync(TEntity entity)
        => await _storeContext.Set<TEntity>().AddAsync(entity);


        public void DeleteAsync(TEntity entity)
        =>  _storeContext.Set<TEntity>().AddAsync(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool TrackChanges)
       => TrackChanges ? await _storeContext.Set<TEntity>().ToListAsync()
            :await _storeContext.Set<TEntity>().AsNoTracking().ToListAsync();


        public async Task<TEntity?> GetByIdAsync(Tkey id)
   => await _storeContext.Set<TEntity>().FindAsync(id);

        public void UpdateAsync(TEntity entity)
       => _storeContext.Set<TEntity>().AddAsync(entity);
    }

  
}

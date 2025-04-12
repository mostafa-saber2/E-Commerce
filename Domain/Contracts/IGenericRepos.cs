using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Contracts
{
  public interface IGenericRepos<TEntity,TKey> where TEntity:BaseEntity<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges = false);
        Task <TEntity?> GetByIdAsync(TKey id);
        Task AddAsync(TEntity entity);
       void DeleteAsync(TEntity entity);
    
        Task UpdateAsync(TEntity entity);
    }
}

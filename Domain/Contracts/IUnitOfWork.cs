using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Domain.Contracts
{
    public interface IUnitOfWork
    {
        public Task<int> SaveChangesAsync();
        IGenericRepos<TEntity, TKey> GetRepos<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
    }
}


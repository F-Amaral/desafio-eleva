using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrefeitura.Domain.DataContracts.Shared
{
    public interface IBaseRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task AddCollectionAsync(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task RemoveByIdAsync(Guid id);
        Task RemoveAsync(TEntity entity);
        Task SaveChangesAsync();
        Task UpdateAsync(TEntity entity);
        Task UpdateCollectionAsync(IEnumerable<TEntity> entities);
    }
}

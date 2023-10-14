using BaseIbge.Domain.Models;

namespace BaseIbge.Infrastructure.Repositories;

public partial class RepositoryBase
{
    public interface IRepositoryBase<T> where T : Entity
    {
        Task<T> Get(int Id);
        void Insert(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task<bool> SaveChangesAsync();
        
    }
}

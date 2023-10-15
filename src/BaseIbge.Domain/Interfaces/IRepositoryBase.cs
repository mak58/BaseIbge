namespace BaseIbge.Domain.Interfaces;

public interface IRepositoryBase<T> where T : class
{
    Task<T> Get(int Id);
    void Insert(T entity);
    void Update(T entity);
    void Remove(T entity);
    Task<bool> SaveChangesAsync();
        
}


using BaseIbge.Domain.Models;
using BaseIbge.Infrastructure.Data;
using static BaseIbge.Infrastructure.Repositories.RepositoryBase;

namespace BaseIbge.Infrastructure.Repositories;

    public class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        private readonly AppDbContext _Context;

        public RepositoryBase(AppDbContext context) => context = _Context;            
        

        async Task<T> IRepositoryBase<T>.Get(int Id)
        {
            return await _Context.Set<T>().FindAsync();
        }   

        void IRepositoryBase<T>.Insert(T entity)
        {
            _Context.Set<T>().Add(entity);
        }

        void IRepositoryBase<T>.Update(T entity)
        {
            _Context.Set<T>().Update(entity);
        }

        void IRepositoryBase<T>.Remove(T entity)
        {
            _Context.Set<T>().Remove(entity);
        }

        async Task<bool> IRepositoryBase<T>.SaveChangesAsync()
        {
            return await _Context.SaveChangesAsync() > 0;
        }
    }

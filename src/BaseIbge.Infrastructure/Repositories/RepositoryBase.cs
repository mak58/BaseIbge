using BaseIbge.Domain.Interfaces;
using BaseIbge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BaseIbge.Infrastructure.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _DbSet;

        public RepositoryBase(AppDbContext context)
        {
            _DbSet = _context.Set<T>();
            context = _context;            
        }
        

        async Task<T> IRepositoryBase<T>.Get(int Id)
        {
            return await _context.Set<T>().FindAsync();
        }   

        void IRepositoryBase<T>.Insert(T entity)
        {
            _DbSet.Add(entity);            
        }

        void IRepositoryBase<T>.Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        void IRepositoryBase<T>.Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        async Task<bool> IRepositoryBase<T>.SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }

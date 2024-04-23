using Back.PagLigeiro.Domain.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.PagLigeiro.Infraestructure.Data.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly SqlContext _sqlContext;

        public BaseRepository(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }
        public async Task<bool> CreateAsync(T item)
        {
            await _sqlContext.Set<T>().AddAsync(item);
            return await _sqlContext.SaveChangesAsync() > 0;
        }

        public async Task DeleteAsync(T item)
        {
            _sqlContext.Set<T>().Remove(item);
            await _sqlContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _sqlContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _sqlContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetIQueryable()
        {

            return _sqlContext.Set<T>();
        }

        public async Task<T> UpdateAsync(T item)
        {
            _sqlContext.Entry(item).State = EntityState.Modified;
            await _sqlContext.SaveChangesAsync();

            return item;
        }
    }
}

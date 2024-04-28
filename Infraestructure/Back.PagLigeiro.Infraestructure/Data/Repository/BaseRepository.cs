using Back.PagLigeiro.Domain.Core.Interfaces.Repository;
using Back.PagLigeiro.Util.LogHelper;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<bool> CommitAsync()
        {
            try
            {
                return await _sqlContext.SaveChangesAsync() > 0;
            }
            catch(Exception e)
            {
                LogHelper.Error(e.Message);
                return false;
            }
        }

        public async Task CreateAsync(T item) => await _sqlContext.Set<T>().AddAsync(item);

        public async Task DeleteAsync(T item) => _sqlContext.Set<T>().Remove(item);

        public async Task<List<T>> GetAllAsync() => await _sqlContext.Set<T>().ToListAsync();

        public async Task UpdateAsync(T item) => _sqlContext.Entry(item).State = EntityState.Modified;

        public async Task<T> GetByIdAsync(int id)
        {
            return await _sqlContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetIQueryable()
        {
            return _sqlContext.Set<T>();
        }
    }
}

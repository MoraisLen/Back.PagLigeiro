using Back.PagLigeiro.Domain.Core.Interfaces.Repository;
using Back.PagLigeiro.Domain.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.PagLigeiro.Domain.Services
{
    public abstract class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _repository;
        public BaseService(IBaseRepository<T> repository)
        {

            _repository = repository;
        }
        public async Task<bool> CreateAsync(T item)
        {
            await _repository.CreateAsync(item);
            return await _repository.CommitAsync();
        }

        public async Task<bool> DeleteAsync(T item)
        {
            await _repository.DeleteAsync(item);
            return await _repository.CommitAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public IQueryable<T> GetIQueryable()
        {
            return _repository.GetIQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(T item)
        {
            await _repository.UpdateAsync(item);
            return await _repository.CommitAsync();
        }
    }
}

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
            return await _repository.CreateAsync(item);
        }

        public async Task DeleteAsync(T item)
        {
            await _repository.DeleteAsync(item);
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

        public async Task<T> UpdateAsync(T item)
        {
            return await _repository.UpdateAsync(item);
        }
    }
}

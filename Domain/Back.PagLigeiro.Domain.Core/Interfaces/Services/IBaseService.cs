using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.PagLigeiro.Domain.Core.Interfaces.Services
{
    public interface IBaseService<T> where T : class
    {
        Task<bool> CreateAsync(T item);
        Task<T> UpdateAsync(T item);
        Task DeleteAsync(T item);
        Task<List<T>> GetAllAsync();
        IQueryable<T> GetIQueryable();
        Task<T> GetByIdAsync(int id);
    }
}

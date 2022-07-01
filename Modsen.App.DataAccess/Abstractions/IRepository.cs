using System.Collections.Generic;
using System.Threading.Tasks;
using Modsen.App.Core.Abstractions;
using Modsen.App.Core.Models;

namespace Modsen.App.DataAccess.Abstractions
{
    public interface IRepository<T> where T : BaseEntity
    {
        public Task AddAsync(T item);
        public Task DeleteAsync(int id);
        public Task UpdateAsync(T item);
        public Task<T> GetByIdAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync();
    }
}
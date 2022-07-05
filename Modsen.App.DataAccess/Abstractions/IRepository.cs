using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dal.Entities;

namespace Modsen.App.DataAccess.Abstractions
{
    public interface IRepository<T> where T : BaseEntity
    {
        public Task AddAsync(T item);
        public Task DeleteAsync(int id);
        public Task UpdateAsync(T item);
        public Task<T> GetByIdAsync(int id);
        public Task<IEnumerable<T>> GetQueueAsync(int offset, int size);
    }
}
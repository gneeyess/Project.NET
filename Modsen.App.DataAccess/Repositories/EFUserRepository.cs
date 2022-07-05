using Modsen.App.Core.Models;
using Modsen.App.DataAccess.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modsen.App.DataAccess.Repositories
{
    public class EFUserRepository : IRepository<User>
    {

        public Task AddAsync(User item)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetByIdAsync(Guid id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetQueueAsync(int offset, int size)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(User item)
        {
            throw new System.NotImplementedException();
        }
    }
}
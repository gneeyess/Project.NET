using Modsen.App.Core.Models;
using Modsen.App.Core.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modsen.App.Core.Services
{
    public interface IUserService
    {
        public Task AddUserAsync(User user);
        public Task<UserDto> GetUserByIdAsync(int id);
        public Task<IEnumerable<UserDto>> GetUserQueryAsync(int page, int size);
        public Task UpdateUserAsync(User user);
        public Task DeleteUserAsync(int id);
    }
}
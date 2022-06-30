using Modsen.App.Core.Models;
using AutoMapper;

namespace Modsen.App.Core.Mapping
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDto>();
        }
    }
}
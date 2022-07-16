using AutoMapper;
using Dal.Entities;
using Dal.Entities.Identity; //User в отличие от остальных в Entities в ней
using Modsen.App.Core.Models.Dto;

namespace Mapping.Mappers
{
	public class UserMapper : Profile
	{
		//CHECK ME

		public UserMapper()
		{
			CreateMap<User, UserDto>();
		}
	}
}

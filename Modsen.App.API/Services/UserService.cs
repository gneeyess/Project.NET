using AutoMapper;
using FluentValidation;
using Modsen.App.Core.Models;
using Modsen.App.Core.Services;
using Modsen.App.DataAccess.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Modsen.App.Core.Models.Dto;

namespace Modsen.App.WebHost.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<User> _userValidator;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork,
            IValidator<User> userValidator, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userValidator = userValidator;
            _mapper = mapper;
        }
        public async Task AddUserAsync(User user)
        {
            var validationResult = await _userValidator.ValidateAsync(user);
            if (validationResult.IsValid)
            {
                await _unitOfWork.UserRepository.AddAsync(user);
                // code 201
            }
            // code 400
        }

        public async Task DeleteUserAsync(int id)
        {
            await _unitOfWork.UserRepository.DeleteAsync(id);
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user != null)
            {
                var result = _mapper.Map<UserDto>(user);
                //code 200
                return result;
            }
            //code 404
            return null; // it will be change later ;(
        }

        public async Task<IEnumerable<UserDto>> GetUserQueryAsync(int page, int size)
        {
            var usersQuery = await _unitOfWork.UserRepository.GetAllAsync();
            usersQuery = usersQuery.ToList();

            var usersDtoQuery = usersQuery.OrderBy(user => user.Id).Select(user => _mapper.Map<UserDto>(user)).ToList();

            var result = usersDtoQuery.Skip(page * size).Take(size).ToList();

            //code 200
            return result;
        }

        public async Task UpdateUserAsync(User user)
        {
            
            var validationResult = await _userValidator.ValidateAsync(user);
            var toUpdateUser = await _unitOfWork.UserRepository.GetByIdAsync(user.Id);
            if (toUpdateUser != null && validationResult.IsValid)
            {
                toUpdateUser.Email = user.Email;
                toUpdateUser.FirstName = user.FirstName;
                toUpdateUser.LastName = user.LastName;
                toUpdateUser.Password = user.Password;
                toUpdateUser.Phone = user.Phone;

                await _unitOfWork.UserRepository.UpdateAsync(toUpdateUser);
                //code 200
            }
            //code 404
        }

    }
}
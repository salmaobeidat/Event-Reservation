using EventReservation.core.Data;
using EventReservation.core.Dto;
using EventReservation.core.Enums;
using EventReservation.core.IRepository;
using EventReservation.core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReservation.infra.Service
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository   _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<int> DeleteUserById(int id)
        {
            return await _usersRepository.DeleteUserById(id);
        }

        public async Task<List<UsersInfoDTO>> GetAllUsers()
        {
            // Returns all registered users based USER enum filteration.
            // Converting From userDto into UserInfoDTO, so we can show only the specific data to the client side.
            var result = await _usersRepository.GetAllUsers();

            var finalResult = result.Where(X => X.Roleid == (int) Roles.SystemRoles.User).Select(userDto => new UsersInfoDTO
            {
                Firstname = userDto.Firstname,
                Lastname = userDto.Lastname,
                Gender = userDto.Gender,
                ImagePath = userDto.ImagePath,
                Email = userDto.Email,
                Password = userDto.Password
            }).ToList();

            return finalResult;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            return await _usersRepository.GetUserById(id);
        }

        public async Task UpdateUserInfo(UpdateUserDTO updateUser)
        {
            await _usersRepository.UpdateUserInfo(updateUser);
        }
    }
}

using EventReservation.core.Data;
using EventReservation.core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReservation.core.IService
{
    public interface IUsersService
    {
        Task<List<UsersInfoDTO>> GetAllUsers();

        Task<UserDto> GetUserById(int id);

        Task UpdateUserInfo(UpdateUserDTO updateUser);

        Task<int> DeleteUserById(int id);
    }
}

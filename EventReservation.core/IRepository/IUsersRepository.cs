using EventReservation.core.Data;
using EventReservation.core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReservation.core.IRepository
{
    public interface IUsersRepository
    {
        Task<List<UserDto>> GetAllUsers();

        Task <UserDto> GetUserById(int id);

        Task UpdateUserInfo(UpdateUserDTO updateUser);

        Task<int> DeleteUserById(int id);
    }
}

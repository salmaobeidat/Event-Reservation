using EventReservation.core.Data;
using EventReservation.core.Dto;
using EventReservation.core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventReservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public async Task<int> DeleteUserById(int id)
        {
            return await _usersService.DeleteUserById(id);
        }

        [HttpGet]
        public async Task<List<UsersInfoDTO>> GetAllUsers()
        {
            return await _usersService.GetAllUsers();
        }

        [HttpGet]
        [Route("GetUserById/{id}")]
        public async Task<UserDto> GetUserById(int id)
        {
            return await _usersService.GetUserById(id);
        }

        [HttpPut]
        public async Task UpdateUserInfo(UpdateUserDTO updateUser)
        {
             await _usersService.UpdateUserInfo(updateUser);
        }
    }
}

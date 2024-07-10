using EventReservation.core.Data;
using EventReservation.core.Dto;
using EventReservation.core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventReservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<UserCredentailsDto> Login(UserCredentailsDto userCredentailsDto)
        {
            return await _authenticationService.Login(userCredentailsDto);
        }

        [HttpPost]
        [Route("Register")]
        public async Task Register([FromBody] UserDto userDto)
        {
           await _authenticationService.Register(userDto);
        }

        [HttpPost]
        [Route("HallOwnerRegister")]
        public async Task HallOwnerRegister(UserDto userDto)
        {
            await _authenticationService.HallOwnerRegister(userDto);
        }

    }
}

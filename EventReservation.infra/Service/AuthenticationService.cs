using EventReservation.core.Data;
using EventReservation.core.Dto;
using EventReservation.core.IRepository;
using EventReservation.core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReservation.infra.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public AuthenticationService(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        public async Task HallOwnerRegister(UserDto userDto)
        {
           await _authenticationRepository.HallOwnerRegister(userDto);
        }

        public async Task<UserCredentailsDto> Login(UserCredentailsDto userCredentailsDto)
        {
           return await _authenticationRepository.Login(userCredentailsDto);
        }
    

        public async Task Register(UserDto userDto)
        {
            await _authenticationRepository.Register(userDto);
        }
    }
}

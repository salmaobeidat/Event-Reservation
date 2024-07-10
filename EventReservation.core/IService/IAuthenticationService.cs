using EventReservation.core.Data;
using EventReservation.core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReservation.core.IService
{
    public interface IAuthenticationService
    {
        Task Register(UserDto userDto);

        Task HallOwnerRegister(UserDto userDto);

        Task<UserCredentailsDto> Login(UserCredentailsDto userCredentailsDto);
    }
}

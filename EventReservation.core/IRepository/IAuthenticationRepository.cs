using EventReservation.core.Data;
using EventReservation.core.Dto;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReservation.core.IRepository
{
    public interface IAuthenticationRepository
    {
        Task Register(UserDto userDto);

        Task HallOwnerRegister(UserDto userDto);

        Task<UserCredentailsDto> Login(UserCredentailsDto userCredentailsDto);
    }
}

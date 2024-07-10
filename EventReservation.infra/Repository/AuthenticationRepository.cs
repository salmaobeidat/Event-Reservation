using Dapper;
using EventReservation.core.Data;
using EventReservation.core.Dto;
using EventReservation.core.Enums;
using EventReservation.core.ICommon;
using EventReservation.core.IRepository;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EventReservation.infra.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IDbContext _dbContext;

        public AuthenticationRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task HallOwnerRegister(UserDto userDto)
        {
            int userRole = (int) Roles.SystemRoles.Hall_Owner;

            var param = new DynamicParameters();

            param.Add("First_Name", userDto.Firstname, DbType.String, ParameterDirection.Input);
            param.Add("Last_Name", userDto.Lastname, DbType.String, ParameterDirection.Input);
            param.Add("Gender", userDto.Gender, DbType.String, ParameterDirection.Input);
            param.Add("ImagePath", userDto.ImagePath, DbType.String, ParameterDirection.Input);
            param.Add("Role_ID", userDto.Roleid = userRole, DbType.Int32, ParameterDirection.Input);
            param.Add("UserIdOut", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var result = await _dbContext.Connection.ExecuteAsync("Authentication_Package.Register", param, commandType: CommandType.StoredProcedure);

            int userId = param.Get<int>("UserIdOut");

            var newParam = new DynamicParameters();

            newParam.Add("UserEmail", userDto.Email, DbType.String, ParameterDirection.Input);
            newParam.Add("UserPassword", userDto.Password, DbType.String, ParameterDirection.Input);
            newParam.Add("UserID", userId, DbType.Int32, ParameterDirection.Input);

            var result2 = await _dbContext.Connection.ExecuteAsync("Authentication_Package.AddCredentials", newParam, commandType: CommandType.StoredProcedure);
        }

        public Task<UserCredentailsDto> Login(UserCredentailsDto userCredentailsDto)
        {
            throw new NotImplementedException();
        }

        public async Task Register(UserDto userDto)
        {

            int userRole = (int) Roles.SystemRoles.User; 

            var param = new DynamicParameters();

            param.Add("First_Name", userDto.Firstname, DbType.String, ParameterDirection.Input);
            param.Add("Last_Name", userDto.Lastname, DbType.String, ParameterDirection.Input);
            param.Add("Gender", userDto.Gender, DbType.String, ParameterDirection.Input);
            param.Add("ImagePath", userDto.ImagePath, DbType.String, ParameterDirection.Input);
            param.Add("Role_ID", userDto.Roleid = userRole, DbType.Int32, ParameterDirection.Input);
            param.Add("UserIdOut", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var result = await _dbContext.Connection.ExecuteAsync("Authentication_Package.Register", param, commandType: CommandType.StoredProcedure);

            int userId = param.Get<int>("UserIdOut");

            var newParam = new DynamicParameters();

            newParam.Add("UserEmail", userDto.Email, DbType.String, ParameterDirection.Input);
            newParam.Add("UserPassword", userDto.Password, DbType.String, ParameterDirection.Input);
            newParam.Add("UserID", userId, DbType.Int32, ParameterDirection.Input);

            var result2 = await _dbContext.Connection.ExecuteAsync("Authentication_Package.AddCredentials", newParam, commandType: CommandType.StoredProcedure);
        }

       
    }
}

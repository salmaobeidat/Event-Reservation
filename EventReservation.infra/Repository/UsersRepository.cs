using Dapper;
using EventReservation.core.Data;
using EventReservation.core.Dto;
using EventReservation.core.Enums;
using EventReservation.core.ICommon;
using EventReservation.core.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReservation.infra.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IDbContext _dbContext;

        public UsersRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> DeleteUserById(int id)
        {
            var param = new DynamicParameters();
            param.Add("UserId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("Users_Package.DeleteUserById", param, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            var result = await _dbContext.Connection.QueryAsync<UserDto>("Users_Package.GetAllUsers", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var param = new DynamicParameters();
            param.Add("UserId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<UserDto>("Users_Package.GetUserById", param, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();

        }

        public async Task UpdateUserInfo(UpdateUserDTO updateUser)
        {
            
            var param = new DynamicParameters();

            param.Add("UserID", updateUser.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("First_Name", updateUser.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Last_Name", updateUser.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("UserGender", updateUser.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("ImagePath", updateUser.ImagePath, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Role_ID", updateUser.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("UserIdOut", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var result = await _dbContext.Connection.ExecuteAsync("Users_Package.UpdateUserInfo", param, commandType: CommandType.StoredProcedure);

            int userId = param.Get<int>("UserIdOut");

            var newParam = new DynamicParameters();

            newParam.Add("UserEmail", updateUser.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            newParam.Add("UserPassword", updateUser.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            newParam.Add("UserID", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result2 = await _dbContext.Connection.ExecuteAsync("Users_Package.UpdateUserCredentials", newParam, commandType: CommandType.StoredProcedure);
        }
    }
}

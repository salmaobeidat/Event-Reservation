using Dapper;
using EventReservation.core.Data;
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
    public class HallRepository : IHallRepository
    {
        private readonly IDbContext _dbContext;

        public HallRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateHall(Hall hall)
        {
            var param = new DynamicParameters();
            param.Add("floorNumber", hall.FloorNumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("hallNumber", hall.HallNumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("numberofTables", hall.NumberOfTables, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("numberofChairs", hall.NumberOfChairs, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("hallCapacity", hall.HallCapacity, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("hallIdentity", hall.HallIdentity, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("hallLocation", hall.HallLocation, dbType: DbType.String, direction: ParameterDirection.Input);
            //check out data type
            param.Add("hallPrice", hall.Price, dbType: DbType.Double, direction: ParameterDirection.Input);
            param.Add("hallAvailabilityDate", hall.HallAvailabilityDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            param.Add("hallServices", hall.Services, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Hmeridians", hall.Meridians, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("hallone_image_path", hall.Hall1ImagePath, DbType.String, ParameterDirection.Input);
            param.Add("halltwo_image_path", hall.Hall2ImagePath, DbType.String, ParameterDirection.Input);
            param.Add("hallthree_image_path", hall.Hall3ImagePath, DbType.String, ParameterDirection.Input);
            param.Add("hallfour_image_path", hall.Hall4ImagePath, DbType.String, ParameterDirection.Input);
            param.Add("hallfive_image_path", hall.Hall5ImagePath, DbType.String, ParameterDirection.Input);
            param.Add("hallsix_image_path", hall.Hall6ImagePath, DbType.String, ParameterDirection.Input);
            param.Add("hallseven_image_path", hall.Hall7ImagePath, DbType.String, ParameterDirection.Input);
            param.Add("HLetitude", hall.Latitude, DbType.String, ParameterDirection.Input);
            param.Add("userID", hall.UserId, DbType.Int32, ParameterDirection.Input);
            param.Add("statusID", hall.StatusId, DbType.Int32, ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("Hall_package.CreateHall", param
               , commandType: CommandType.StoredProcedure);
        }

        public Task DeleteHall(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Hall>> GetAllHalls()
        {
            throw new NotImplementedException();
        }

        public Task<Hall> GetHallById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateHall(Hall hall)
        {
            throw new NotImplementedException();
        }
    }
}

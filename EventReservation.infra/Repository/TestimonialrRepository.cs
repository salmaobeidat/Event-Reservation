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
    public class TestimonialrRepository : ITestimonialRepository
    {
        private IDbContext _dbContext;

        public TestimonialrRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateTestimonial(Testimonial testimonial)
        {
            var param = new DynamicParameters();
            param.Add("Test_Content", testimonial.TestimonialContent, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("CreateDate", testimonial.CreationDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            param.Add("UserID", testimonial.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("Is_Deleted", testimonial.Isdeleted, dbType: DbType.Boolean, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("Testimonial_Package.CreateTestimonial", param, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteTestimonial(int id)
        {
            var param = new DynamicParameters();
            param.Add("TestimonailID", id, DbType.Int32, ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("Testimonial_Package.DeleteTestimonialById", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Testimonial>> GetTestimonials()
        {
            var result = await _dbContext.Connection.QueryAsync<Testimonial>("Testimonial_Package.GetAllTestimonials", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}

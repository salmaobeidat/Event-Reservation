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
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly IDbContext _dbContext;

        public FeedbackRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateFeedback(Feedback feedback)
        {
            var param = new DynamicParameters();
            param.Add("feedback_content", feedback.FeedbackContent, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("rating", feedback.Rating, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("user_id", feedback.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("hall_id", feedback.HallId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("Feedback_Package.CreateFeedback", param, commandType: CommandType.StoredProcedure);



        }

        public async Task<int> DeleteFeedback(int id)
        {
            var param = new DynamicParameters();
            param.Add("feedback_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.ExecuteAsync("Feedback_Package.DeleteFeedback", param, commandType: CommandType.StoredProcedure);
            return 5;
        }

        public async Task<List<Feedback>> GetAllFeedbacks()
        {
            var result = await _dbContext.Connection.QueryAsync<Feedback>("Course_Package.GetAllCourses", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

    private int test()
    {
            return 1;
    }        
}
}
        
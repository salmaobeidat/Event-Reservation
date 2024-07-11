using EventReservation.core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReservation.core.IRepository
{
    public interface IFeedbackRepository
    {
        Task<List<Feedback>> GetAllFeedbacks();      
        Task CreateFeedback(Feedback feedback);
        Task DeleteFeedback(int id);
    }
}

using EventReservation.core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReservation.core.IService
{
    public interface IFeedbackService
    {
        Task<List<Feedback>> GetAllFeedbacks();    
        Task CreateFeedback(Feedback feedback);       
        Task<int> DeleteFeedback(int id);
    }
}

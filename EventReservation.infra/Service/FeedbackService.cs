using EventReservation.core.Data;
using EventReservation.core.IRepository;
using EventReservation.core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReservation.infra.Service
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<List<Feedback>> GetAllFeedbacks()
        {
            return await _feedbackRepository.GetAllFeedbacks();
        }

        public async Task CreateFeedback(Feedback feedback)
        {
            await _feedbackRepository.CreateFeedback(feedback); 
        }

        public async Task DeleteFeedback(int id)
        {
            await _feedbackRepository.DeleteFeedback(id);
        }

         
    }
}

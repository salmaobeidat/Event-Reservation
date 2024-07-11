using EventReservation.core.Data;
using EventReservation.core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventReservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public async Task<List<Feedback>> GetAllFeedbacks()
        {
            return await _feedbackService.GetAllFeedbacks();
        }

        [HttpPost]
        public async Task CreateFeedback([FromBody] Feedback feedback)
        {
            await _feedbackService.CreateFeedback(feedback);
        }

        [HttpDelete("{id}")]
        public async Task DeleteFeedback(int id)
        {
            await _feedbackService.DeleteFeedback(id);
        }
    }
}

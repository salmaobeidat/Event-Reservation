using EventReservation.core.Data;
using EventReservation.core.IService;
using EventReservation.infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventReservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public async Task<List<Testimonial>> GetTestimonials()
        {
            return await _testimonialService.GetTestimonials();
        }

        [HttpPost]
        public async Task CreateTestimonial([FromBody] Testimonial testimonial)
        {
            await _testimonialService.CreateTestimonial(testimonial);
        }

     

        [HttpDelete("{id}")] 
        public async Task DeleteTestimonial(int id)
        {
            await _testimonialService.DeleteTestimonial(id);
        }
    }
}

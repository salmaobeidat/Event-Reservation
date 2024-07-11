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
    public class TestimonialService : ITestimonialService
    {
        private readonly ITestimonialRepository _testimonialRepository;

        public TestimonialService(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }

        public async Task CreateTestimonial(Testimonial testimonial)
        {
            await _testimonialRepository.CreateTestimonial(testimonial);
        }

        public async Task DeleteTestimonial(int id)
        {
            await _testimonialRepository.DeleteTestimonial(id);
        }

        public async Task<List<Testimonial>> GetTestimonials()
        {
            return await _testimonialRepository.GetTestimonials();
        }
    }
}

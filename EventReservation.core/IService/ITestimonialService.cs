using EventReservation.core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReservation.core.IService
{
    public interface ITestimonialService
    {
        Task<List<Testimonial>> GetTestimonials();
        Task CreateTestimonial(Testimonial testimonial);
        Task<int> DeleteCourse(int id); 
    }
}

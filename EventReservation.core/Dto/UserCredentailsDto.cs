using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReservation.core.Dto
{
    public class UserCredentailsDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int UserID { get; set; }
    }
}

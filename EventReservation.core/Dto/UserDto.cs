﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReservation.core.Dto
{
    public class UserDto
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Gender { get; set; }
        public string? ImagePath { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? Roleid { get; set; }
    }
}

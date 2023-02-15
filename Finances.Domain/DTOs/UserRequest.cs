using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Domain.DTOs
{
    public class UserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IncomeRequest Income { get; set; }
    }
}

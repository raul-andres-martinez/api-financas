using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Finances.Domain.DTOs
{
    public class UserRequest
    {
        public string Name { get; set; }
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }
        public string Password { get; set; }
        public IncomeRequest Income { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Domain.DTOs
{
    public class UserAndIncomeRequest
    {
        public UserRequest UserRequest { get; set; }
        public IncomeRequest IncomeRequest { get; set; }
    }
}

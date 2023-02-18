using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Domain.DTOs
{
    public class IncomeRequest
    {
        public decimal Value { get; set; }
        public int PaymentDay { get; set; }
    }
}

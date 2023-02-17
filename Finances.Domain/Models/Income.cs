using Finances.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Domain.Models
{
    public class Income : BaseEntity
    {
        public decimal Value { get; set; }
        public bool HasDebit { get; private set; }
        public List<Debits> Debits { get; private set; }
        public double TotalDebits { get; private set; }
        public decimal DisponibleAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime PaymentDay { get; set; }

        public Income()
        {
            Debits = new List<Debits>();
        }

        public void CalculateDebitsTotal()
        {
            if (HasDebit)
            {
                TotalDebits = Debits.Sum(d => d.DebitValue);
            }
            else
            {
                TotalDebits = 0;
            }
        }

        public void SetHasDebit()
        {
            if ((double)Value > 1903.98)
            {
                HasDebit = true;
            }
            else
            {
                HasDebit = false;
            }
        }
    }

    public class Debits
    {
        public string Name { get; set; }
        public double DebitValue { get; set; }
        public int Installments { get; set; }
    }
}
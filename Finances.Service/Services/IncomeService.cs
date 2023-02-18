using AutoMapper;
using Finances.Domain.DTOs;
using Finances.Domain.Entities.Models;
using Finances.Domain.Interfaces.Repositories;
using Finances.Domain.Interfaces.Services;
using Finances.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Service.Services
{
    public class IncomeService : IIncomeService
    {
        private readonly IBaseRepository<Income> _incomeRepository;
        private readonly IMapper _mapper;

        public IncomeService(IBaseRepository<Income> incomeRepository, IMapper mapper)
        {
            _incomeRepository = incomeRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(IncomeRequest request)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request));

            var newIncome = _mapper.Map<Income>(request);
            newIncome.CreatedAt = DateTime.Now;

            newIncome.SetHasDebit();
            newIncome.CalculateDebitsTotal();
            newIncome.GetPaymentDay(request.PaymentDay);

            await _incomeRepository.InsertAsync(newIncome);
        }

        public async Task UpdateIncomeValueAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
//var paymentDay = request.PaymentDay;
//var currentMonth = DateTime.Now.Month;
//var currentYear = DateTime.Now.Year;

//if (paymentDay < DateTime.Now.Day)
//{
//    currentMonth++;

//    if (currentMonth > 12)
//    {
//        currentMonth = 1;
//        currentYear++;
//    }
//}

//newIncome.PaymentDay = new DateTime(currentYear, currentMonth, paymentDay);
using Finances.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Domain.Interfaces.Services
{
    public interface IIncomeService
    {
        Task AddAsync(IncomeRequest request);
        Task UpdateIncomeValueAsync(int id);
    }
}

using AutoMapper;
using Finances.Domain.DTOs;
using Finances.Domain.Models;

namespace Finances.Domain.Profiles
{
    internal class IncomeProfile : Profile
    {
        public IncomeProfile()
        {
            CreateMap<IncomeRequest, Income>();
            CreateMap<Income, IncomeRequest>();
        }
    }
}

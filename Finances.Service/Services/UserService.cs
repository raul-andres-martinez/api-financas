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
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly IIncomeService _incomeService;
        private readonly IMapper _mapper;

        public UserService(IBaseRepository<User> userRepository, IMapper mapper, IIncomeService incomeService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _incomeService = incomeService;
        }

        public async Task AddAsync(UserRequest userRequest, IncomeRequest incomeRequest)
        {
            _ = userRequest ?? throw new ArgumentNullException(nameof(userRequest));

            var user = await _userRepository.SelectAsync(x => x.Email == userRequest.Email);

            if (user.Any())
            {
                throw new Exception("Cadastro já existente.");
            }

            var newUser =  _mapper.Map<User>(userRequest);
            newUser.CreatedDate = DateTime.Now;


            await _userRepository.InsertAsync(newUser);
            await _incomeService.AddAsync(incomeRequest);
        }

        public Task<IEnumerable<User>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

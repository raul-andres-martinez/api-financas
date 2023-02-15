using AutoMapper;
using Finances.Domain.DTOs;
using Finances.Domain.Entities.Models;
using Finances.Domain.Interfaces.Repositories;
using Finances.Domain.Interfaces.Services;
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
        private readonly IMapper _mapper;

        public UserService(IBaseRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(UserRequest request)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request));

            var user = await _userRepository.SelectAsync(x => x.Email == request.Email);

            if (user.Any())
            {
                throw new Exception("Cadastro já existente.");
            }

            var newUser =  _mapper.Map<User>(request);
            newUser.CreatedDate = DateTime.Now;

            _userRepository.Insert(newUser);
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

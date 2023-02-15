using Finances.Domain.DTOs;
using Finances.Domain.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Finances.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task AddAsync(UserRequest request);
        //Task<bool> DeleteAsync(int id);
        Task<IEnumerable<User>> GetAsync();
        Task<User> GetByIdAsync(int id);
        //Task<User> UpdateAsync<TValidator>(User user);
    }
}

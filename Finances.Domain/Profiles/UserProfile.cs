using AutoMapper;
using Finances.Domain.DTOs;
using Finances.Domain.Entities.Models;

namespace Finances.Domain.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRequest, User>();
            CreateMap<User, UserRequest>();
        }
    }
}

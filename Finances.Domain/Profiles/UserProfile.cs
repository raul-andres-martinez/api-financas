using AutoMapper;
using Finances.Domain.DTOs;
using Finances.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

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

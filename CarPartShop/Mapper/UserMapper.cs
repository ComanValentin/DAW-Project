using AutoMapper;
using CarPartShop.DTO;
using CarPartShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPartShop.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<RegisterRequest, User>();
            CreateMap<User, AuthenticationResponse>();
        }
    }
}

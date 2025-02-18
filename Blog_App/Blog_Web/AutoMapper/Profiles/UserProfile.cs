﻿using AutoMapper;
using ProgramerBlog.Entities.Concrete;
using ProgramerBlog.Entities.Conreate;
using ProgramerBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_Web.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDto, User>();

            CreateMap<User, UserUpdateDto>();

            CreateMap<UserUpdateDto, User>();
        }
    }
}

﻿using AutoMapper;
using ProgramerBlog.Entities.Conreate;
using ProgramerBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramerBlog.Services.AutoMapper.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddDto, Category>()
               .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<CategoryUpdateDto, Category>()
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Category, CategoryUpdateDto>();
        }
    }
}

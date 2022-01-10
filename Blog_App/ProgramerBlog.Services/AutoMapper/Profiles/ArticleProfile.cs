﻿using AutoMapper;
using ProgramerBlog.Entities.Conreate;
using ProgramerBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramerBlog.Services.AutoMapper.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleAddDto, Article>().ForMember(dest=> dest.CreateDate,opt => opt.MapFrom(x=> DateTime.Now));
            CreateMap<ArticleUpdateDto, Article>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Article,ArticleUpdateDto>();
        }
    }
}

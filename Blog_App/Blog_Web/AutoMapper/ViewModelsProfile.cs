using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog_Web.Areas.Admin.Models;
using ProgramerBlog.Entities.Dtos;

namespace Blog_Web.AutoMapper
{
    public class ViewModelsProfile:Profile
    {
        public ViewModelsProfile()
        {
            CreateMap<ArticleAddViewModel, ArticleAddDto>();
            CreateMap<ArticleUpdateDto,ArticleUpdateViewModel>().ReverseMap();
        }
    }
}

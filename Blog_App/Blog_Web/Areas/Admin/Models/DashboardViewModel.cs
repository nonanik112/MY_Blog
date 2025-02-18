﻿using ProgramerBlog.Entities.Dtos;

namespace Blog_Web.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int CategoriesCount { get; set; }
        
        public int ArticlesCount { get; set; }
        
        public int CommentsCount { get; set; }
        
        public int UsersCount { get; set; }
        
        public ArticleListDto Articles { get; set; }

    }
}

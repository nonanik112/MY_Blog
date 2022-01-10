using ProgramerBlog.Entities.Concrete;
using ProgramerBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace ProgramerBlog.Entities.Conreate
{
    public class Article : EntityBase,IEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Thumbnail { get; set; }

        public DateTime Date { get; set; }

        public int ViewsCount { get; set; } = 0;

        public int CommetCount { get; set; } = 0;

        public string SeoAuthor { get; set; }

        public string SeoDescription { get; set; }

        public String SeoTags { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<Comment> Comments { get; set; }
       
    }
}

using ProgramerBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramerBlog.Entities.Conreate
{
    public class Comment : EntityBase,IEntity
    {
        public string Text { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }

        public override bool IsActive { get; set; } = false;

    }
}

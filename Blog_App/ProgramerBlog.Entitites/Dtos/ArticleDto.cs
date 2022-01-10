using ProgramerBlog.Entities.Conreate;
using ProgramerBlog.Shared.Entities.Abstract;
using ProgramerBlog.Shared.Utilities.Results.Abstract.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramerBlog.Entities.Dtos
{
    public class ArticleDto : DtoGetBase
    {
        public Article Article { get; set; }

        
    }
}

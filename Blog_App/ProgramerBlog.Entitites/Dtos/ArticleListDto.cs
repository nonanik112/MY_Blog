using ProgramerBlog.Entities.Conreate;
using ProgramerBlog.Shared.Entities.Abstract;
using ProgramerBlog.Shared.Utilities.Results.Abstract.ComplexTypes;
using ProgramerBlog.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramerBlog.Entities.Dtos
{
    public class ArticleListDto : DtoGetBase
    {
        public IList<Article> Articles  { get; set; }

        

    }
}

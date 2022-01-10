using ProgramerBlog.Entities.Conreate;
using ProgramerBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramerBlog.Entities.Dtos
{
    public class CategoryListDto : DtoGetBase
    {
        public IList<Category> Categories { get; set; }
    }
}

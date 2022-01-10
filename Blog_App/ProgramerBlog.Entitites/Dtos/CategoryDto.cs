using ProgramerBlog.Entities.Conreate;
using ProgramerBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramerBlog.Entities.Dtos
{
    public class CategoryDto : DtoGetBase
    {
        public Category Category { get; set; }
    }
}

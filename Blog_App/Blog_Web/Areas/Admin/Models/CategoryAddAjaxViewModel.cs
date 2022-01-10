using ProgramerBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_Web.Areas.Admin.Models
{
    public class CategoryAddAjaxViewModel
    {
        public CategoryAddDto CategoryAdd { get; set; }

        public string CategoryAddPartial { get; set; }

        public CategoryDto CategoryDto { get; set; }
    }
}

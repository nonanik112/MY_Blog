using ProgramerBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_Web.Areas.Admin.Models
{
    public class CategoryUpdateAjaxViewModel
    {
        public CategoryAddDto CategoryUpdateDto { get; set; }

        public string CategoryUpdatePartial { get; set; }

        public CategoryDto CategoryDto { get; set; }
    }
}

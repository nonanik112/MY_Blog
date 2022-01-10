using ProgramerBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_Web.Areas.Admin.Models
{
    public class UserRoleAssignAjaxViewModel
    {
        public UserRoleAssignDto UserRoleAssignDto { get; set; }

        public string RoleAssignPartial { get; set; }

        public UserDto UserDto { get; set; }
    }
}

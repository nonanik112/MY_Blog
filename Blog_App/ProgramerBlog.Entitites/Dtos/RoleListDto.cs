using ProgramerBlog.Entities.Conreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramerBlog.Entities.Dtos
{
    public class RoleListDto
    {
        public IList<Role> Roles { get; set; }

        public string RoleName { get; set; }

        public bool HasRole { get; set; }
    }
}

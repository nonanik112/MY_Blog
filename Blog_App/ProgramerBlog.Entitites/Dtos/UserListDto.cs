using ProgramerBlog.Entities.Concrete;
using ProgramerBlog.Shared.Entities.Abstract;
using System.Collections.Generic;

namespace ProgramerBlog.Entities.Dtos
{
    public class UserListDto : DtoGetBase
    {
        public IList<User> Users { get; set; }
    }
}

using ProgramerBlog.Entities.Concrete;
using ProgramerBlog.Shared.Entities.Abstract;

namespace ProgramerBlog.Entities.Dtos
{

    public class UserDto : DtoGetBase
    {
        public User User { get; set; }
    }
}

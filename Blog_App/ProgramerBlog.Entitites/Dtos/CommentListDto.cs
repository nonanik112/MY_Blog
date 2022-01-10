using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramerBlog.Entities.Conreate;

namespace ProgramerBlog.Entities.Dtos
{
    public class CommentListDto
    {
        public IList<Comment> Comments { get; set; }
    }
}

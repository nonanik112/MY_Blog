using ProgramerBlog.Entities.Conreate;
using ProgramerBlog.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramerBlog.Data.Abstract
{
   public interface ICommentRepository : IEntityRepository<Comment>
    {
    }
}

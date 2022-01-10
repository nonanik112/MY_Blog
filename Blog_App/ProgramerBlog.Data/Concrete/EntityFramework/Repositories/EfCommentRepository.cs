using Microsoft.EntityFrameworkCore;
using ProgramerBlog.Data.Abstract;
using ProgramerBlog.Entities.Conreate;
using ProgramerBlog.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramerBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EfCommentRepository : EfEntityRepositoryBase<Comment>, ICommentRepository
    {
        public EfCommentRepository(DbContext context) : base(context)
        {
        }
    }
}

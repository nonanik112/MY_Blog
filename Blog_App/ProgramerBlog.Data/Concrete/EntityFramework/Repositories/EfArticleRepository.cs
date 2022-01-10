using Microsoft.EntityFrameworkCore;
using ProgramerBlog.Data.Abstract;
using ProgramerBlog.Entities.Conreate;
using ProgramerBlog.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgramerBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EfArticleRepository : EfEntityRepositoryBase<Article>, IArticleRepository
    {
        public EfArticleRepository(DbContext context) : base(context)
        {
        }

       
    }
}

using Microsoft.EntityFrameworkCore;
using ProgramerBlog.Data.Abstract;
using ProgramerBlog.Data.Concrete.EntitFramework.Contexts;
using ProgramerBlog.Entities.Conreate;
using ProgramerBlog.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProgramerBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EfCategoryRepository : EfEntityRepositoryBase<Category>, ICategoryRepository
    {
        public EfCategoryRepository(DbContext context) : base(context)
        {
        }

        public async Task<Category> GetById(int categoryId)
        {
          return await  ProgrammerBlogContext.Categories.SingleOrDefaultAsync(c => c.Id == categoryId);
        }
        private ProgrammerBlogContext ProgrammerBlogContext
        {
            get
            {
              return _context as ProgrammerBlogContext;
            }
         }
    }
}

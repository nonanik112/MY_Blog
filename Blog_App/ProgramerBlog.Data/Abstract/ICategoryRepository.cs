using ProgramerBlog.Entities.Conreate;
using ProgramerBlog.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgramerBlog.Data.Abstract
{
    public interface ICategoryRepository : IEntityRepository<Category>
    {
        Task<Category> GetById(int categoryId);
        
    }
}

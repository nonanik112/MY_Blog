using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProgramerBlog.Data.Abstract;
using ProgramerBlog.Entities.Conreate;
using ProgramerBlog.Shared.Data.Abstract;

namespace ProgramerBlog.Data.Abstract
{
    public interface IArticleRepository : IEntityRepository<Article>
    {
       
    }
}

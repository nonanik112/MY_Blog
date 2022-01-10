using System.Threading.Tasks;
using ProgramerBlog.Data.Abstract;
using ProgramerBlog.Data.Concrete.EntitFramework.Contexts;
using ProgramerBlog.Data.Concrete.EntityFramework.Repositories;

namespace ProgramerBlog.Data.Concrete
{
    public class UnitOfWork:IUnitOfWork
    {  private readonly ProgrammerBlogContext _context;
        private EfArticleRepository _articleRepository;
        private EfCategoryRepository _categoryRepository;
        private EfCommentRepository _commentRepository;

        public UnitOfWork(ProgrammerBlogContext context)
        {
            _context = context;
        }

        public IArticleRepository Articles => _articleRepository ?? new EfArticleRepository(_context);
        public ICategoryRepository Categories => _categoryRepository ?? new EfCategoryRepository(_context);
        public ICommentRepository Comments => _commentRepository ?? new EfCommentRepository(_context);
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
         // dotnet ef --startup-project ../Blog_Web migrations add InitialCreate
         // # dotnet ef --startup-project ../Blog_Web database update
    }
}

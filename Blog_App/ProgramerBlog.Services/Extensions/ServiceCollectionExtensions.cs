using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProgramerBlog.Data.Abstract;
using ProgramerBlog.Data.Concrete.EntitFramework.Contexts;
using ProgramerBlog.Entities.Conreate;
using ProgramerBlog.Services.Concrete;
using ProgramerBlog.Services.Abstract;
using ProgramerBlog.Entities.Concrete;
using ProgramerBlog.Data.Concrete;

namespace ProgramerBlog.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<ProgrammerBlogContext>(options=>options.UseSqlServer("Server=MSI; Database=ProgrammersBlog;uid=sa;pwd=1234;Trusted_Connection=True;MultipleActiveResultSets=true"));
            serviceCollection.AddIdentity<User, Role>(options =>
            {
                // User Password Options
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                // User Username and Email Options
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+$";
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ProgrammerBlogContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<IArticleService, ArticleManager>();
            serviceCollection.AddScoped<ICommentService, CommentManager>();
            return serviceCollection;
        }
    }
}


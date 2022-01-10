using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgramerBlog.Data.Concrete.EntityFramework.Mappings;
using ProgramerBlog.Entities.Concrete;
using ProgramerBlog.Entities.Conreate;
using ProgramerBlog.Entities.Conrete;

namespace ProgramerBlog.Data.Concrete.EntitFramework.Contexts
{
    public class ProgrammerBlogContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        @"Server=(localdb)\ProjectsV13;Database=ProgrammersBlog;Trusted_Connection=True;Connect Timeout=30;MultipleActiveResultSets=True;");
        //}
        public ProgrammerBlogContext(DbContextOptions<ProgrammerBlogContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RoleClaimMap());
            modelBuilder.ApplyConfiguration(new UserClaimMap());
            modelBuilder.ApplyConfiguration(new UserLoginMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());
            modelBuilder.ApplyConfiguration(new UserTokenMap());

        }
    }
}

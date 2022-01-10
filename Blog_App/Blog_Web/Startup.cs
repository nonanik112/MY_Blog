using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProgramerBlog.Services.AutoMapper.Profiles;
using ProgramerBlog.Services.Extensions;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Blog_Web.AutoMapper.Profiles;
using Blog_Web.Helpers.Abstract;
using Blog_Web.Helpers.Concrete;
using Microsoft.Extensions.Configuration;
using Blog_Web.AutoMapper;

namespace ProgramerBlog.Mvc
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(options => 
            {
                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(value => "Bu alan boþ geçilmemelidir.");
            }).AddRazorRuntimeCompilation().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                //opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            }).AddNToastNotifyNoty();
            services.AddSession();
            services.AddAutoMapper(typeof(CategoryProfile), typeof(ArticleProfile),typeof(UserProfile),typeof(ViewModelsProfile),typeof(CommentProfile));
            services.LoadMyServices(connectionString:Configuration.GetConnectionString("LocalDB"));
            services.AddScoped<IImageHelper, ImageHelper>();
            services.ConfigureApplicationCookie(options => 
            {  // Güvenlik alaný 
                options.LoginPath = new PathString("/Admin/Auth/Login");
                options.LogoutPath = new PathString("/Admin/Auth/logout");
                options.Cookie = new CookieBuilder
                { //Güvenlik alaný
                    Name = "Blog_Web",
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    SecurePolicy = CookieSecurePolicy.Always // Güvenlik politikasý 
                };
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = System.TimeSpan.FromDays(3);
                options.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseSession();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseNToastNotify();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}

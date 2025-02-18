﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Blog_Web.Areas.Admin.Models;
using ProgramerBlog.Entities.Concrete;
using System.Threading.Tasks;

namespace Blog_Web.Areas.Admin.ViewComponents
{
     public class UserMenuViewComponent:ViewComponent
    {
        private readonly UserManager<User> _userManager;

        public UserMenuViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
                return Content("Kullanıcı bulunamadı.");
            return View(new UserViewModel
            {
                User = user
            });
        }
    }
}



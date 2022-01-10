using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProgramerBlog.Services.Abstract;
using ProgramerBlog.Shared.Utilities.Results.Abstract.ComplexTypes;
using ProgramerBlog.Entities.Dtos;
using Blog_Web.Areas.Admin.Models;
using System.Text.Json;
using AutoMapper;
using Blog_Web.Helpers.Abstract;
using ProgramerBlog.Shared.Utilities.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ProgramerBlog.Entities.Conreate;
using ProgramerBlog.Entities.Concrete;

namespace Blog_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin,Editör")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService,UserManager<User> userManager, IMapper mapper,IImageHelper imageHelper):base(userManager,mapper,imageHelper)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.GetAllByNonDeletedAsync();
            return View(result.Data);

        }
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_CategoryAddPartial");
        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.AddAsync(categoryAddDto, LoggedInUser.UserName);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var categoryAddAjaxModel = JsonSerializer.Serialize(new CategoryAddAjaxViewModel
                    {
                        CategoryDto = result.Data,
                        CategoryAddPartial = await this.RenderViewToStringAsync("_CategoryAddPartial", categoryAddDto)
                    });
                    return Json(categoryAddAjaxModel);
                }
            }
            var categoryAddAjaxErrorModel = JsonSerializer.Serialize(new CategoryAddAjaxViewModel
            {
                CategoryAddPartial = await this.RenderViewToStringAsync("_CategoryAddPartial", categoryAddDto)
            });
            return Json(categoryAddAjaxErrorModel);

        }
        [HttpGet]
        public async Task<IActionResult> Update(int categoryId)
        {
            var result = await _categoryService.GetCategoryUpdateDtoAsync(categoryId);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return PartialView("_CategoryUpdatePartial", result.Data);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.UpdateAsync(categoryUpdateDto, "Nonanik");
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var categoryUpdateAjaxModel = JsonSerializer.Serialize(new CategoryUpdateAjaxViewModel
                    {
                        CategoryDto = result.Data,
                        CategoryUpdatePartial = await this.RenderViewToStringAsync("_CategoryUpdatePartial", categoryUpdateDto)
                    });
                    return Json(categoryUpdateAjaxModel);
                }
            }
            var categoryUpdateAjaxErrorModel = JsonSerializer.Serialize(new CategoryUpdateAjaxViewModel
            {
                CategoryUpdatePartial = await this.RenderViewToStringAsync("_CategoryUpdatePartial", categoryUpdateDto)
            });
            return Json(categoryUpdateAjaxErrorModel);

        }

        public async Task<JsonResult> GetAllCategories()
        {
            var result = await _categoryService.GetAllByNonDeletedAsync();
            var categories = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                //ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(categories);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int categoryId)
        {
            var result = await _categoryService.DeleteAsync(categoryId, LoggedInUser.UserName);
            var deletedCategory = JsonSerializer.Serialize(result.Data);
            return Json(deletedCategory);
        }
    }
}

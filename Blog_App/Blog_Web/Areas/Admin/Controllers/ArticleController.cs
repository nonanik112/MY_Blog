﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog_Web.Areas.Admin.Models;
using Blog_Web.Helpers.Abstract;
using Microsoft.AspNetCore.Identity;
using ProgramerBlog.Entities.Complex_Types;
using ProgramerBlog.Entities.Conreate;
using ProgramerBlog.Entities.Dtos;
using ProgramerBlog.Services.Abstract;
using ProgramerBlog.Shared.Utilities.Results.Abstract.ComplexTypes;
using System.Text.Json;
using System.Text.Json.Serialization;
using NToastNotify;
using ProgramerBlog.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace Blog_Web.Areas.Admin.Controllers
{ 
    [Area("Admin")]
    public class ArticleController : BaseController
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IToastNotification _toastNotification;

        public ArticleController(IArticleService articleService, ICategoryService categoryService,UserManager<User> userManager ,IMapper mapper, IImageHelper imageHelper, IToastNotification toastNotification):base( userManager,mapper, imageHelper)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _toastNotification = toastNotification;
        }
        [Authorize(Roles = "UstAdmin,Article.Read")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _articleService.GetAllByNonDeletedAsync();
            if(result.ResultStatus==ResultStatus.Success) return View(result.Data);
            return NotFound();
        }
        [Authorize(Roles = "UstAdmin,Article.Create")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var result = await _categoryService.GetAllByNonDeletedAndActiveAsync();
            if (result.ResultStatus==ResultStatus.Success)
            {
                return View(new ArticleAddViewModel
                {
                    Categories = result.Data.Categories
                });
            }

            return NotFound();
        }
        [Authorize(Roles = "UstAdmin,Article.Create")]
        [HttpPost]
        public async Task<IActionResult> Add(ArticleAddViewModel articleAddViewModel)
        {
            if (ModelState.IsValid)
            {
                var articleAddDto = Mapper.Map<ArticleAddDto>(articleAddViewModel);
                var imageResult = await ImageHelper.Upload(articleAddViewModel.Title,
                    articleAddViewModel.ThumbnailFile, PictureType.Post);
                articleAddDto.Thumbnail = imageResult.Data.FullName;
                var result = await _articleService.AddAsync(articleAddDto, LoggedInUser.UserName,LoggedInUser.Id);
                if (result.ResultStatus==ResultStatus.Success)
                {
                    _toastNotification.AddSuccessToastMessage(result.Message, new ToastrOptions
                    {
                        Title = "Başarılı İşlem!"
                    });
                    return RedirectToAction("Index", "Article");
                }
                else
                {
                    ModelState.AddModelError("",result.Message);
                }
            }

            var categories = await _categoryService.GetAllByNonDeletedAndActiveAsync();
            articleAddViewModel.Categories = categories.Data.Categories;
            return View(articleAddViewModel);
        }
        [Authorize(Roles = "UstAdmin,Article.Update")]
        [HttpGet]
        public async Task<IActionResult> Update(int articleId)
        {
            var articleResult = await _articleService.GetArticleUpdateDtoAsync(articleId);
            var categoriesResult = await _categoryService.GetAllByNonDeletedAndActiveAsync();
            if (articleResult.ResultStatus==ResultStatus.Success && categoriesResult.ResultStatus==ResultStatus.Success)
            {
                var articleUpdateViewModel = Mapper.Map<ArticleUpdateViewModel>(articleResult.Data);
                articleUpdateViewModel.Categories = categoriesResult.Data.Categories;
                return View(articleUpdateViewModel);
            }
            else
            {
                return NotFound();
            }
        }
        [Authorize(Roles = "UstAdmin,Article.Update")]
        [HttpPost]
        public async Task<IActionResult> Update(ArticleUpdateViewModel articleUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                bool isNewThumbnailUploaded = false;
                var oldThumbnail = articleUpdateViewModel.Thumbnail;
                if (articleUpdateViewModel.ThumbnailFile!=null)
                {
                    var uploadedImageResult = await ImageHelper.Upload(articleUpdateViewModel.Title,
                        articleUpdateViewModel.ThumbnailFile, PictureType.Post);
                    articleUpdateViewModel.Thumbnail = uploadedImageResult.ResultStatus == ResultStatus.Success
                        ? uploadedImageResult.Data.FullName
                        : "postImages/defaultThumbnail.jpg";
                    if (oldThumbnail!= "postImages/defaultThumbnail.jpg")
                    {
                        isNewThumbnailUploaded = true;
                    }
                }
                var articleUpdateDto = Mapper.Map<ArticleUpdateDto>(articleUpdateViewModel);
                var result = await _articleService.UpdateAsync(articleUpdateDto, LoggedInUser.UserName);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    if (isNewThumbnailUploaded)
                    {
                        ImageHelper.Delete(oldThumbnail);
                    }
                    _toastNotification.AddSuccessToastMessage(result.Message, new ToastrOptions
                    {
                        Title = "Başarılı İşlem!"
                    });
                    return RedirectToAction("Index", "Article");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }

            var categories = await _categoryService.GetAllByNonDeletedAndActiveAsync();
            articleUpdateViewModel.Categories = categories.Data.Categories;
            return View(articleUpdateViewModel);
        }
        [Authorize(Roles = "UstAdmin,Article.Delete")]
        [HttpPost]
        public async Task<JsonResult> Delete(int articleId)
        {
            var result = await _articleService.DeleteAsync(articleId, LoggedInUser.UserName);
            var articleResult = JsonSerializer.Serialize(result);
            return Json(articleResult);
        }
        [Authorize(Roles = "SuperAdmin,Article.Read")]
        [HttpGet]
        public async Task<JsonResult> GetAllArticles()
        {
            var articles = await _articleService.GetAllByNonDeletedAndActiveAsync();
            var articleResult = JsonSerializer.Serialize(articles, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(articleResult);
        }

        [Authorize(Roles = "SuperAdmin,Article.Read")]
        [HttpGet]
        public async Task<IActionResult> DeletedArticles()
        {
            var result = await _articleService.GetAllByDeletedAsync();
            return View(result.Data);

        }
        [Authorize(Roles = "SuperAdmin,Article.Read")]
        [HttpGet]
        public async Task<JsonResult> GetAllDeletedArticles()
        {
            var result = await _articleService.GetAllByDeletedAsync();
            var articles = JsonSerializer.Serialize(result, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(articles);
        }
        [Authorize(Roles = "SuperAdmin,Article.Update")]
        [HttpPost]
        public async Task<JsonResult> UndoDelete(int articleId)
        {
            var result = await _articleService.UndoDeleteAsync(articleId, LoggedInUser.UserName);
            var undoDeleteArticleResult = JsonSerializer.Serialize(result);
            return Json(undoDeleteArticleResult);
        }
        [Authorize(Roles = "SuperAdmin,Article.Delete")]
        [HttpPost]
        public async Task<JsonResult> HardDelete(int articleId)
        {
            var result = await _articleService.HardDeleteAsync(articleId);
            var hardDeletedArticleResult = JsonSerializer.Serialize(result);
            return Json(hardDeletedArticleResult);
        }
    }
}

using Microsoft.AspNetCore.Http;
using ProgramerBlog.Entities.Dtos;
using ProgramerBlog.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgramerBlog.Entities.Complex_Types;

namespace Blog_Web.Helpers.Abstract
{
    public interface IImageHelper
    {
        Task<IDataResult<ImageUploadedDto>> Upload(string name, IFormFile pictureFile, PictureType pictureType, string folderName = null);
        IDataResult<ImageDeletedDto> Delete(string pictureName);
    }
}

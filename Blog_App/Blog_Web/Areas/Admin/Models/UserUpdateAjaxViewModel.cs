﻿using ProgramerBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_Web.Areas.Admin.Models
{
    public class UserUpdateAjaxViewModel
    {
        public UserUpdateDto UserUpdateDto { get; set; }

        public string UserUpdatePartial { get; set; }

        public UserDto UserDto { get; set; }
    }
}

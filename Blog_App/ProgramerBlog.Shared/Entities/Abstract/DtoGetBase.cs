using ProgramerBlog.Shared.Utilities.Results.Abstract.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramerBlog.Shared.Entities.Abstract
{
    public abstract class DtoGetBase 
    {
        public virtual ResultStatus ResultStatus { get; set; }

        public virtual string Message { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramerBlog.Shared.Utilities.Results.Abstract
{
    public interface IDataResult<T> : IResult
    {
        public T Data { get;}
        public IEnumerable<T> List { get; set; }
        public IResult Result { get; set; }
    }
}

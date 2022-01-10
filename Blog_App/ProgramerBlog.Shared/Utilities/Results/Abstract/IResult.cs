using System;
using ProgramerBlog.Shared.Utilities.Results.Abstract.ComplexTypes;

namespace ProgramerBlog.Shared.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; } 
        public string Message { get; }
        public Exception Exception { get; }
    }
}

using ProgramerBlog.Shared.Utilities.Results.Abstract;
using ProgramerBlog.Shared.Utilities.Results.Abstract.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramerBlog.Shared.Utilities.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(ResultStatus resultStatus, T data)
        {
            ResultStatus = resultStatus;
            Data = data;
        }

        public DataResult(ResultStatus resultStatus,string message, T data)
        {
            ResultStatus = resultStatus;
            Data = data;
            Message = message;
        }

        public DataResult(ResultStatus resultStatus, string message, T data, Exception exception)
        {
            ResultStatus = resultStatus;
            Data = data;
            Message = message;
            Exception = exception;
        }
        
        public ResultStatus  ResultStatus { get; }

        public string Message { get; }

        public Exception Exception { get; }

        public T Data { get; }
        public IEnumerable<T> List { get; set; }
        public IResult Result { get; set; }
    }
}

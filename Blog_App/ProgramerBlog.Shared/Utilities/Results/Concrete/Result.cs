using ProgramerBlog.Shared.Utilities.Results.Abstract;
using ProgramerBlog.Shared.Utilities.Results.Abstract.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramerBlog.Shared.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }
        public Result(ResultStatus resultStatus,string mesasage)
        {
            ResultStatus = resultStatus;
            Message = mesasage;
        }
        public Result(ResultStatus resultStatus, string mesasage,Exception exception)
        {
            ResultStatus = resultStatus;
            Message = mesasage;
            Exception = exception;
        }

        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public Exception Exception { get; }
        // new Result(ResultStatus.Error,"İşlem başarısız oldu",exception,message,exception)
    }
}

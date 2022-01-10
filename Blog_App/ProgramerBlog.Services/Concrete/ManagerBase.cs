using AutoMapper;
using ProgramerBlog.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramerBlog.Services.Concrete
{
    public class ManagerBase
    {
        protected IUnitOfWork UnitOfWork { get; }

        public ManagerBase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        protected IMapper Mapper {get;}
    }
}

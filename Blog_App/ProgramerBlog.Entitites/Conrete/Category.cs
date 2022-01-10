using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProgramerBlog.Shared.Entities.Abstract;

namespace ProgramerBlog.Entities.Conreate
{
    public class Category : EntityBase, IEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}

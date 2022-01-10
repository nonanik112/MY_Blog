using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramerBlog.Shared.Entities.Abstract
{

    public abstract class EntityBase
    {
        public virtual int Id { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;

        public virtual bool IsDeleted { get; set; } = false;

        public virtual bool IsActive { get; set; } = true;

        public string CreatedByName { get; set; } = "Admin";

        public string ModifiedByName { get; set; } = "Admin";

        public virtual string Note { get; set; }
    }
}

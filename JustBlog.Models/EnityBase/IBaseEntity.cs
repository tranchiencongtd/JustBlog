using JustBlog.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Models.EnityBase
{
    public interface IBaseEntity
    {
        int Id { get; set; }

        Status Status { get; set; }

        DateTime CreatedOn { get; set; }

        DateTime UpdatedOn { get; set; }

    }
}

using JustBlog.Core.Infrastructures;
using JustBlog.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Core.IRepositories
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        Tag GetTagByUrlSlug(string urlSlug);

        IEnumerable<int> AddTagByString(string tags);
    }
}

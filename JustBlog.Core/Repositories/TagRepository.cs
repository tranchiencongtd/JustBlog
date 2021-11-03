using JustBlog.Core.Infrastructures;
using JustBlog.Core.IRepositories;
using JustBlog.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Core.Repositories
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {

        }

        public Tag GetTagByUrlSlug(string urlSlug)
        {
            var result = context.Tags.Where(t => t.UrlSlug == urlSlug).FirstOrDefault(); ;
            return result;
        }

    }
}

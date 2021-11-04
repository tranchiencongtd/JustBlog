using JustBlog.Common;
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

        public IEnumerable<int> AddTagByString(string tags)
        {
            var tagNames = tags.Split(';');

            foreach (var tagName in tagNames)
            {
                var tagExisting = this.dbSet.Where(t => t.Name.Trim().ToLower() == tagName.Trim().ToLower()).Count();
                if (tagExisting == 0)
                {
                    var tag = new Tag()
                    {
                        Name = tagName,
                        UrlSlug = UrlHepler.FrientlyUrl(tagName)
                    };
                    this.dbSet.Add(tag);
                }
            }
            this.context.SaveChanges();

            foreach (var tagName in tagNames)
            {
                var tagExisting = this.dbSet.FirstOrDefault(t => t.Name.Trim().ToLower() == tagName.Trim().ToLower());
                if (tagExisting != null)
                {
                    yield return tagExisting.Id;
                }
            }

        }

        public Tag GetTagByUrlSlug(string urlSlug)
        {
            var result = context.Tags.Where(t => t.UrlSlug == urlSlug).FirstOrDefault();
            return result;
        }
    }
}

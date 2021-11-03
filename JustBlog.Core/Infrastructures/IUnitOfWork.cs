using JustBlog.Core.IRepositories;
using JustBlog.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Core.Infrastructures
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository PostRepository { get; }
        ITagRepository TagRepository { get; }
        ICategoryRepository CategoryRepository { get; }

        AppDbContext AppDbContext { get; }
        int SaveChange();
        Task<int> SaveChangesAsync();
    }
}

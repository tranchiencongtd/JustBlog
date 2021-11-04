using JustBlog.Core.IRepositories;
using JustBlog.Core.Repositories;
using JustBlog.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Core.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        private ITagRepository tagRepository;
        private IPostRepository postRepository;
        private ICategoryRepository categoryRepository;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }

        public IPostRepository PostRepository
        {
            //AddSingleton, AddScoped, AddTransient
            get
            {
                if (this.postRepository == null)
                {
                    this.postRepository = new PostRepository(this.context);
                }
                return this.postRepository;
            }
            //get => new DepartmentRepository(context);
        }

        public ITagRepository TagRepository
        {
            get
            {
                if (this.tagRepository == null)
                {
                    this.tagRepository = new TagRepository(this.context);
                }
                return this.tagRepository;
            }
        }
 

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new CategoryRepository(this.context);
                }
                return this.categoryRepository;
            }
        }
        public AppDbContext AppDbContext => this.context;

       

        public void Dispose()
        {
            this.context.Dispose();
        }

        public int SaveChange()
        {
            return this.context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.context.SaveChangesAsync();
        }
    }
}


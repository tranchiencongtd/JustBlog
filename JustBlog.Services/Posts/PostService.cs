using AutoMapper;
using JustBlog.Core.Infrastructures;
using JustBlog.Models.Entities;
using JustBlog.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Post FindPost(int year, int month, string urlSlug)
        {
            return this.unitOfWork.PostRepository.FindPost(year, month, urlSlug);
        }

        public IEnumerable<PostViewModel> GetAll()
        {
            var posts = this.unitOfWork.PostRepository.GetAll();
            return Mapper.Map<IEnumerable<PostViewModel>>(posts);
        }

        public IEnumerable<PostViewModel> GetPostsByCategory(string slug)
        {
            var posts = this.unitOfWork.PostRepository.GetPostsByCategory(slug);
            return Mapper.Map<IEnumerable<PostViewModel>>(posts);
        }
    }
}

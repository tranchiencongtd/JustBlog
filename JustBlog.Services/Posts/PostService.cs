using AutoMapper;
using JustBlog.Core.Infrastructures;
using JustBlog.Models.Entities;
using JustBlog.ViewModels.Posts;
using JustBlog.ViewModels.Results;
using JustBlog.ViewModels.Tags;
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

        public PostDetailViewModel GetPostByYearMonthUrlSlug(int year, int month, string urlSlug)
        {
            var postExisting = this.unitOfWork.PostRepository.FindPost(year, month, urlSlug);
            var tags = new List<TagViewModel>();
            foreach (var postTag in postExisting.PostTags)
            {
                var tag = this.unitOfWork.TagRepository.Find(postTag.TagId);
                tags.Add(Mapper.Map<TagViewModel>(tag));
            }
            var postDetail = new PostDetailViewModel()
            {
                Title = postExisting.Title,

                ViewCount = postExisting.ViewCount,

                UrlSlug = postExisting.UrlSlug,

                CreatedOn = postExisting.CreatedOn,

                PostContent = postExisting.PostContent,

                Tags = tags,
            };

            return postDetail;
        } 

        public IEnumerable<PostViewModel> GetAll()
        {
            var posts = this.unitOfWork.PostRepository.GetAll();
            return Mapper.Map<IEnumerable<PostViewModel>>(posts);
        }

        public IEnumerable<PostViewModel> GetPostsByCategoryUrlSlug(string slugUrl)
        {
            var posts = this.unitOfWork.PostRepository.GetPostsByCategoryUrlSlug(slugUrl);
            return Mapper.Map<IEnumerable<PostViewModel>>(posts);
        }

        public ResponseResult Create(CreatePostViewModel request)
        {
            try
            {
                //1. add tag vao database
                var tagIds = this.unitOfWork.TagRepository.AddTagByString(request.Tags);
                // 2. create postTag
                var postTags = new List<PostTag>();
                foreach (var tagId in tagIds)
                {
                    var postTag = new PostTag()
                    {
                        TagId = tagId
                    };
                    postTags.Add(postTag);
                }

                var post = new Post()
                {
                    Title = request.Title,
                    UrlSlug = request.UrlSlug,
                    PostContent = request.PostContent,
                    ViewCount = request.ViewCount,
                    CategoryId = (int)request.CategoryId,
                    PostTags = postTags
                };
                this.unitOfWork.PostRepository.Add(post);
                this.unitOfWork.SaveChange();
                return new ResponseResult();
            }
            catch (Exception ex)
            {
                return new ResponseResult(ex.Message);
            }
        }

        public ResponseResult Delete(int Id)
        {
            try
            {
                this.unitOfWork.PostRepository.Delete(Id);
                this.unitOfWork.SaveChange();
                return new ResponseResult();
            }
            catch (Exception ex)
            {
                return new ResponseResult(ex.Message);
            }
        }
    }
}

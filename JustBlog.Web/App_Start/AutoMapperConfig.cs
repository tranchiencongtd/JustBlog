using AutoMapper;
using JustBlog.Models.Entities;
using JustBlog.ViewModels.Categories;
using JustBlog.ViewModels.Posts;
using JustBlog.ViewModels.Tags;

namespace JustBlog.Web.App_Start
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //CreateMap<CreatePostViewModel, Post>()
            //    .ForMember(des => des.Title, opt => opt.MapFrom(src => src.Title))
            //    .ForMember(des => des.Content, opt => opt.MapFrom(src => src.Content))
            //    .ReverseMap();

            // Post
            CreateMap<Post, PostViewModel>().ReverseMap();
            CreateMap<Post, PostDetailViewModel>().ReverseMap();

            //Category
            CreateMap<Category, CategoryViewModel>().ReverseMap();

            //Tag
            CreateMap<Tag, TagViewModel>().ReverseMap();
        }

    }
}
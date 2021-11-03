using AutoMapper;
using JustBlog.Models.Entities;
using JustBlog.ViewModels.Categories;
using JustBlog.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            CreateMap<Post, PostViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.ViewModels.Posts
{
    public class CreatePostViewModel
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        [MaxLength(100, ErrorMessage = "Tiêu đề bài viết không được quá 100 ký tự")]
        public string Title { get; set; }

        [Display(Name = "Short Desciption")]
        [Required(ErrorMessage = "Mô tả không được để trống")]
        [MaxLength(50, ErrorMessage = "Mô tả 500 ký tự")]
        public string ShortDescription { get; set; }

        [Display(Name = "URL SLUG")]
        public string UrlSlug { get; set; }

        [Display(Name = "Post Content")]
        [Required(ErrorMessage = "Nội dung bài viết không được để trống")]
        public string PostContent { get; set; }

        [Display(Name = "Views")]
        public int ViewCount { get; set; }


        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [Display(Name = "Tags")]
        [Required(ErrorMessage = "Tags không được để trống")]
        public string Tags { get; set; }

    }
}

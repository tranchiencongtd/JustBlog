using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.ViewModels.Categories
{
    public class CreateCategoryViewModel
    {
        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        [MaxLength(100, ErrorMessage = "Tiêu đề bài viết không được quá 100 ký tự")]
        public string Name { get; set; }

        [Display(Name = "Url Link")]
        public string UrlSlug { get; set; }
    }
}

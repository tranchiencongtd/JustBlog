using JustBlog.Models.EnityBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Models.Entities
{
    public class Post : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(1024)]
        public string ShortDescription { get; set; }

        [StringLength(255)]
        public string UrlSlug { get; set; }

        public int CategoryId { get; set; }

        public int ViewCount { get; set; }

        public string PostContent { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<PostTag> PostTags { get; set; }
    }
}

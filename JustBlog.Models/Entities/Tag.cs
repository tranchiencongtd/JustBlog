using JustBlog.Models.EnityBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Models.Entities
{
    public class Tag : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string UrlSlug { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        int Count { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}

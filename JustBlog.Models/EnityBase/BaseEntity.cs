using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JustBlog.Models.Enums;

namespace JustBlog.Models.EnityBase
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime UpdatedOn { get; set; }

    }
}

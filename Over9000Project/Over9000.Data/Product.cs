using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Over9000.Data
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
        public int ProductReviewId { get; set; }
        [ForeignKey(nameof(ProductReviewId))]
        public virtual ProductReview ProductReview { get; set; }
    }
}

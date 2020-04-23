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
        public string ProductName { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        public int ProductReviewsId { get; set; }
        [ForeignKey(nameof(ProductReviewsId))]
        public virtual ProductReviews ProductReviews { get; set; }
    }
}

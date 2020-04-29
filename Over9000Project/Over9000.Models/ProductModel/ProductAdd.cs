using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Over9000.Models
{
    public class ProductAdd
    {
        [Required]
        [MinLength(4, ErrorMessage = "Must be at least 4 characters...")]
        [MaxLength(100, ErrorMessage = "Must be within 100 characters...")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Display(Name = "Product Price")]
        public decimal ProductPrice { get; set; }
        [MaxLength(2000, ErrorMessage = "Must be less than 2000 characters")]
        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }
        [Display(Name = "Product Review ID")]
        public int ProductReviewId { get; set; }
        [Display(Name = "Date Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }
    }
}

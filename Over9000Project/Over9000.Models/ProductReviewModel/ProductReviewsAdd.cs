using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Over9000.Models
{
    public class ProductReviewsAdd
    {
        [Required]
        [MinLength(4, ErrorMessage = "Must be at least 4 characters...")]
        [MaxLength(100, ErrorMessage = "Must be within 100 characters...")]
        [Display(Name = "Product Review Title")]
        public string ReviewTitle { get; set; }
        [MaxLength(2000, ErrorMessage = "Must be less than 2000 characters...")]
        [Display(Name = "Product Review Text")]
        public string ReviewText { get; set; }
        [Range(1,5, ErrorMessage = "Please select between 1 and 5 Stars")]
        [Display(Name = "Product Review Stars")]
        public int ReviewStars { get; set; }
        [Display(Name = "Date Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Product Review ID")]
        public int ProductReviewId { get; set; }
    }
}

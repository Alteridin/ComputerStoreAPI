using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Over9000.Models
{
    public class ProductReviewsListItem
    {
        [Display(Name = "Product Review ID")]
        public int ProductReviewId { get; set; }
        [Display(Name = "Product Review Title")]
        public string ReviewTitle { get; set; }
        [Display(Name = "Product Review Text")]
        public string ReviewText { get; set; }
        [Range(1, 5, ErrorMessage = "Please select between 1 and 5 Stars")]
        [Display(Name = "Product Review Stars")]
        public int ReviewStars { get; set; }
        [Display(Name = "Date Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Date Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}

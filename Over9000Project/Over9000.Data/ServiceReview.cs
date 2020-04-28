using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Over9000.Data
{
    public class ServiceReview
    {
        [Key]
        public int ServiceReviewId { get; set; }
        [Required]
        public Guid ServiceReviewOwnerId { get; set; }
        [Required]
        public string ServiceReviewTitle { get; set; }
        [Required]
        public string ServiceReviewText { get; set; }
        [Required]
        public int ServiceReviewStars { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}

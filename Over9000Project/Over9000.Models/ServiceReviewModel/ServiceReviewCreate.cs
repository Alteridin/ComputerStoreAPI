using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Over9000.Models.ServiceReviewModel
{
    public class ServiceReviewCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "Please enter less than 100 characters.")]
        [Display(Name = "Service Review Title")]
        public string ServiceReviewTitle { get; set; }
        [MaxLength(2000, ErrorMessage = "Please enter less than 2000 characters.")]
        [Display(Name = "Service Review Text")]
        public string ServiceReviewText { get; set; }
        [Range(1,5, ErrorMessage = "Please enter a whole number between 1 and 5.")]
        [Display(Name = "Service Review Stars")]
        public int ServiceReviewStars { get; set; }
        [Display(Name = "Date Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Service Review ID")]
        public int ServiceReviewId { get; set; }
    }
}

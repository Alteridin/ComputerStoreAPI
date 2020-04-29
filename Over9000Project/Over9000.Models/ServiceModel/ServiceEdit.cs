using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Over9000.Models.ServiceModel
{
    public class ServiceEdit
    {
        [Display(Name = "Service ID")]
        public int ServiceId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "Please enter less than 100 characters.")]
        [Display(Name = "Service Name")]
        public string ServiceName { get; set; }
        [Display(Name = "Service Price")]
        public decimal ServicePrice { get; set; }
        [MaxLength(2000, ErrorMessage = "Please enter less than 2000 characters.")]
        [Display(Name = "Service Description")]
        public string ServiceDescription { get; set; }
        [Display(Name = "Date Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }
        [Display(Name = "Service Review ID")]
        public int ServiceReviewId { get; set; }
    }
}

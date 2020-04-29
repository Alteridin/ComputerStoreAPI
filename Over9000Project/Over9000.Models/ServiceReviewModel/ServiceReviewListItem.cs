using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Over9000.Models.ServiceReviewModel
{
    public class ServiceReviewListItem
    {
        [Display(Name = "Service Review ID")]
        public int ServiceReviewId { get; set; }
        [Display(Name = "Service Review Title")]
        public string ServiceReviewTitle { get; set; }
        [Display(Name = "Service Review Text")]
        public string ServiceReviewText { get; set; }
        [Display(Name = "Service Review Stars")]
        public int ServiceReviewStars { get; set; }
        [Display(Name = "Date Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Date Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}

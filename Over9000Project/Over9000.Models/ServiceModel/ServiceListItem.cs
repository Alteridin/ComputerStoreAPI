using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Over9000.Models.ServiceModel
{
    public class ServiceListItem
    {
        [Display(Name = "Service Id")]
        public int ServiceId { get; set; }
        [Display(Name = "Service Name")]
        public string ServiceName { get; set; }
        [Display(Name = "Service Price")]
        public decimal ServicePrice { get; set; }
        [Display(Name = "Service Description")]
        public string ServiceDescription { get; set; }
        [Display(Name = "Date Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
        public int ServiceReviewId { get; set; }
        public string ServiceReviewTitle { get; set; }
        public int ServiceReviewStars { get; set; }
    }
}

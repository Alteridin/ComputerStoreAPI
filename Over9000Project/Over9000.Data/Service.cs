using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Over9000.Data
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        [Required]
        public Guid ServiceOwnerId { get; set; }
        [Required]
        public string ServiceName { get; set; }
        [Required]
        public decimal ServicePrice { get; set; }
        [Required]
        public string ServiceDescription { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
        public int ServiceReviewId { get; set; }
        [ForeignKey(nameof(ServiceReviewId))]
        public virtual ServiceReview ServiceReview { get; set; }
    }
}

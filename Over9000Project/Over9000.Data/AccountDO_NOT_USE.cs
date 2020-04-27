using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* namespace Over9000.Data
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public int SavedPaymentInformationId { get; set; }
        [ForeignKey(nameof(SavedPaymentInformationId))]
        public virtual SavedPaymentInformation SavedPaymentInformation { get; set; }
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual List<Product> Product { get; set; }
        public int ProductReviewId { get; set; }
        [ForeignKey(nameof(ProductReviewId))]
        public virtual ProductReview ProductReview { get; set; }
    }
}
*/
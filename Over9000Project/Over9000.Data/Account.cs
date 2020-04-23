﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Over9000.Data
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        public int SPInfoId { get; set; }
        [ForeignKey(nameof(SPInfoId))]
        public virtual SavedPaymentInformation SavedPaymentInformation { get; set; }
        public int AccountHistoryId { get; set; }
        [ForeignKey(nameof(AccountHistoryId))]
        public virtual AccountHistory AccountHistory { get; set; }
        public int ProductReviewsId { get; set; }
        [ForeignKey(nameof(ProductReviewsId))]
        public virtual ProductReviews ProductReviews { get; set; }
    }
}

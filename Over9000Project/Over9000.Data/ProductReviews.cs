﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Over9000.Data
{
    public class ProductReviews
    {
        [Key]
        public int ProductReviewsId { get; set; }
        [Required]
        public string ReviewTitle { get; set; }
        [Required]
        public string ReviewText { get; set; }
        [Required]
        public int ReviewStars { get; set; }
    }
}

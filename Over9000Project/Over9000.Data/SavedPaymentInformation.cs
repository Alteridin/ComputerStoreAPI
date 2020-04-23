﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Over9000.Data
{
    public class SavedPaymentInformation
    {
        [Key]
        public int SavedPaymentInformationId { get; set; }
        [Required]
        public string SavedPaymentInformationName { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        [Required]
        public int CVV { get; set; }
    }
}

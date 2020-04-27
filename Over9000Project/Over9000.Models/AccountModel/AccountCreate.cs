using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Over9000.Models
{
    public class AccountCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string UserName { get; set; }

        [MaxLength(40, ErrorMessage = "There are too many characters in this field.")]
        public string Email { get; set; }
    }
}

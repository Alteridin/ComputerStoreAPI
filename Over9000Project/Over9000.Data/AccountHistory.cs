using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Over9000.Data
{
    public class AccountHistory
    {
        [Key]
        public int AccountHistoryId { get; set; }
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual List<Product> Product { get; set; }
    }
}

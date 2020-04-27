using Over9000.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Over9000.Models
{
    public class AccountHistoryListItem
    {
        public int AccountHistoryId { get; set; }
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual List<Product> Product { get; set; }
    }
}

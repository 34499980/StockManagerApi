using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    [Table("SALE_STOCK", Schema = "dbo")]
    public class Sale_Stock
    {
        public int IdSale { get; set; }
        public long IdStock { get; set; }

        [ForeignKey("IdSale")]
        public virtual Sale Sale { get; set; }
        [ForeignKey("IdStock")]
        public virtual Stock Stock { get; set; }
    }
}

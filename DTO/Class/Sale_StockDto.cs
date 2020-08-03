using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO.Class
{
    [Table("SALE_STOCK", Schema = "dbo")]
    public class Sale_StockDto
    {
        public int IdSale { get; set; }
        public int IdStock { get; set; }

        [ForeignKey("IdSale")]
        public virtual SaleDto Sale { get; set; }
        [ForeignKey("IdStock")]
        public virtual StockDto Stock { get; set; }
    }
}

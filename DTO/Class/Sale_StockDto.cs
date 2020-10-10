using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO.Class
{
   
    public class Sale_StockDto
    {
        public int IdSale { get; set; }
        public long IdStock { get; set; }

    
        public SaleDto Sale { get; set; }
       
        public StockDto Stock { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO.Class
{
    [Table("STOCK_SUCURSAL", Schema = "dbo")]
    public class Stock_SucursalDto
    {
        
        public int IdSucursal { get; set; }
        public int IdStock { get; set; }
        public int Unity { get; set; }

          

        public virtual SucursalDto Sucursal { get; set; }

        public virtual StockDto Stock { get; set; }
    }

}

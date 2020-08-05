using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO.Class
{
    [Table("STOCK_SUCURSAL", Schema = "dbo")]
    public class Stock_SucursalDto
    {
        [Key]
        public int IdSucursal { get; set; }
        public long IdStock { get; set; }
        public int Unity { get; set; }


        [ForeignKey("IdSucursal")]
        public virtual SucursalDto Sucursal { get; set; }
        [ForeignKey("IdStock")]
        public virtual StockDto Stock { get; set; }
    }

}

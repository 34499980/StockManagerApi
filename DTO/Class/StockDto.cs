using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO.Class
{
    [Table("STOCK", Schema = "dbo")]
    public class StockDto
    {
        [Key]
        public int ID { get; set; }
        public string Code { get; set; }
        public string QR { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int IdSucursal { get; set; }
        public int IdState { get; set; }
        public string Description { get; set; }

        public virtual Stock_StateDto State { get; set; }
        public virtual SucursalDto Sucursal { get; set; }
    }
}

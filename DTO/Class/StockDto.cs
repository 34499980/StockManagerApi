using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text;

namespace DTO.Class
{
    [Table("STOCK", Schema = "dbo")]
    public class StockDto
    {
        [Key]
        public Int64 ID { get; set; }
        public string Code { get { return ID.ToString().PadLeft(10, '0'); } set { Code = value; } }
        public string QR { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int IdSucursal { get; set; }
        public int IdState { get; set; }
        public string Description { get; set; }

        [ForeignKey("IdState")]
        public virtual Stock_StateDto State { get; set; }
        [ForeignKey("IdSucursal")]
        public virtual SucursalDto Sucursal { get; set; }
        public virtual int Unity { get; set; }
 
    }
}

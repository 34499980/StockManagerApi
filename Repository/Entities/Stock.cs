using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text;

namespace Repository.Entities
{
    [Table("STOCK", Schema = "dbo")]
    public class Stock
    {
        [Key]
        public long ID { get; set; }
        public string Code { get; set; }
        public string QR { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int IdSucursal { get; set; }
        public int IdState { get; set; }
        public string Description { get; set; }

        [ForeignKey("IdState")]
        public virtual Stock_State State { get; set; }
        [ForeignKey("IdSucursal")]
        public virtual Office Sucursal { get; set; }
        [NotMapped]
        public virtual ICollection<Stock_Office> Stock_Office { get; set; }
        [NotMapped]
        public virtual ICollection<Dispatch_Stock> Dispatch_Stock { get; set; }
        [NotMapped]
        public  int Unity { get; set; }
       

    }
}

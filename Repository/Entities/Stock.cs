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
        public int IdOffice { get; set; }
        public int IdState { get; set; }
        public string Description { get; set; }
        public string File { get; set; }

        [ForeignKey("IdState")]
        public virtual Stock_State State { get; set; }
        [ForeignKey("IdOffice")]
        public virtual Office Office { get; set; }       
        public virtual ICollection<Stock_Office> Stock_Office { get; set; }
        [NotMapped]
        public virtual ICollection<Dispatch_Stock> Dispatch_Stock { get; set; }
        [NotMapped]
        public  int Unity { get; set; }
       

    }
}

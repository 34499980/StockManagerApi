using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
   // [Table("STOCK_SUCURSAL", Schema = "dbo")]
    public class Stock_Office
    {
      //  [Key]
        public int ID { get; set; }
        public int IdOffice { get; set; }
        public long IdStock { get; set; }
        public int Unity { get; set; }


        [ForeignKey("IdOffice")]
        public virtual Office Office { get; set; }
       [ForeignKey("IdStock")]
        public virtual Stock Stock { get; set; }
    }

}

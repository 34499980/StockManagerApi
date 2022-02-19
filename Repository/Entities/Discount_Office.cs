using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
   
    [Table("DISCOUNT_OFFICE", Schema = "dbo")]
    public class Discount_Office
    {
        [Key]
        public int ID { get; set; }
        public int IdOffice { get; set; }
        public long IdDiscount { get; set; }
      

        [ForeignKey("IdOffice")]
        public virtual Office Office { get; set; }
        //[ForeignKey("IdStock")]
        [ForeignKey("IdDiscount")]
        public virtual Discount DISCOUNT { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
   
    [Table("DISCOUNT_PAYMENTTYPE", Schema = "dbo")]
    public class Discount_PaymentType
    {
        [Key]
        public int ID { get; set; }
        public int IdPaymentType { get; set; }
        public long IdDiscount { get; set; }
      

        [ForeignKey("IdPaymentType")]
        public virtual PaymentType PaymentType { get; set; }
        //[ForeignKey("IdStock")]
        [ForeignKey("IdDiscount")]
        public virtual Discount DISCOUNT { get; set; }

       // public virtual ICollection<Discount_PaymentType> DISCOUNT_PAYMENTTYPE { get; set; }
    }
}

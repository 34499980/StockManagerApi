using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{

    [Table("DISCOUNT", Schema = "dbo")]
    public class Discount
    {

        [Key]
        public long ID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int Percent { get; set; }
        public int IdPaymentType { get; set; }
        public long IdStock { get; set; }
        public int IdUser { get; set; }

        [ForeignKey("IdPaymentType")]
        public virtual PaymentType PaymentType { get; set; }
        public virtual ICollection<Discount_PaymentType> PaymentTypeList { get; set; }

        public virtual ICollection<Discount_Office> Discount_Office { get; set; }
        //[ForeignKey("IdStock")]
        [ForeignKey("IdStock")]
        public virtual Stock Stock { get; set; }
        [ForeignKey("IdUser")]
        public virtual User User { get; set; }

      //  public virtual ICollection<Discount_Office> Discount_Office { get; set; }
    }

 }

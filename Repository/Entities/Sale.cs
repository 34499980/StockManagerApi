using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{ 
    [Table("SALE", Schema = "dbo")]
    public class Sale
    {
        [Key]
        public int ID { get; set; }
        public DateTime DateProces { get; set; }
        public int IdUser { get; set; }
        public float Amount { get; set; }
        public string Refer { get; set; }
        public int IdSucursal { get; set; }
        public int IdState { get; set; }


        [ForeignKey("IdSucursal")]
        public virtual Office Sucursal { get; set; }

        [ForeignKey("IdState")]
        public virtual Sale_State State { get; set; }
        [ForeignKey("IdUser")]
        public virtual User User { get; set; }

    }
}

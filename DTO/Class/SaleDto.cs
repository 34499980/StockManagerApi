using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO.Class
{
    [Table("SALE", Schema = "dbo")]
    public class SaleDto
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
        public virtual SucursalDto Sucursal { get; set; }

        [ForeignKey("IdState")]
        public virtual Sale_StateDto State { get; set; }
        [ForeignKey("IdUser")]
        public virtual UserDto User { get; set; }

    }
}

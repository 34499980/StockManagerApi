using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO.Class
{
    [Table("SALE_STATE", Schema = "dbo")]
    public class Sale_StateDto
    {
        [Key]
        public int ID { get; set; }
        public string Descripcion { get; set; }
    }
}

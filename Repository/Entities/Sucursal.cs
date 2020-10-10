using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    [Table("SUCURSAL", Schema = "dbo")]
    public class Sucursal
    {
       
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int PostalCode { get; set; }

      //  public virtual ICollection<Stock_SucursalDto> Stock_Sucursal { get; set; }
    }
}

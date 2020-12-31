using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    [Table("OFFICE", Schema = "dbo")]
    public class Office
    {
       
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public Boolean Active { get; set; } 

      //  public virtual ICollection<Stock_OfficeDto> Stock_Sucursal { get; set; }
    }
}

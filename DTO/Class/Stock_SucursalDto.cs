using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO.Class
{
    public class Stock_SucursalDto
    {
     
        public int ID { get; set; }
        public int IdSucursal { get; set; }
        public long IdStock { get; set; }
        public int Unity { get; set; }


   
    }

}

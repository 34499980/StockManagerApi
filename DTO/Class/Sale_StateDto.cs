using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO.Class
{
 
    public class Sale_StateDto : StateBaseDto
    {
      
        public int ID { get; set; }
        public string Descripcion { get; set; }
    }
}

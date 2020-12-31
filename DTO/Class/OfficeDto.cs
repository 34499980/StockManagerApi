using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO.Class
{
   
    public class OfficeDto
    {
       
      
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public bool Active { get; set; }

     
    }
}

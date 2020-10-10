using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace DTO.Class
{
  
    public class Dispatch_StockDto
    {
      
        public int ID { get; set; }
        public int IdDispatch { get; set; }
        public long IdStock { get; set; }
        public int Unity { get; set; }
        public int UnityRead { get; set; }

    
       
     
        public  StockDto Stock { get; set; }
    }
}

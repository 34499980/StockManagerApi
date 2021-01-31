using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text;

namespace DTO.Class
{
 
    public class StockDto
    {
    
        public long ID { get; set; }
        public string Code { get; set; }
        public string QR { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int IdOffice { get; set; }
        public int? IdState { get; set; }
        public string Description { get; set; }
        public string File { get; set; }

     
        public  Stock_StateDto State { get; set; }
     
        public  OfficeDto Office { get; set; }
      
        public  ICollection<Stock_OfficeDto> Stock_Office { get; set; }
        public  ICollection<Dispatch_StockDto> Dispatch_Stock { get; set; }
      
        public  int Unity { get; set; }
        public int Count { get; set; }


    }
}

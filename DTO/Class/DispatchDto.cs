using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace DTO.Class
{
  
    public class DispatchDto
    {

  
        public int ID { get; set; }
        public DateTime DateCreate { get; set; }
        public int IdUserOrigin { get; set; }
        public int? IdUserDestiny { get; set; }
        public int IdOrigin { get; set; }
        public int IdDestiny { get; set; }
        public int IdCountry { get; set; }
        public int IdState { get; set; }
        public DateTime? DateDispatched { get; set; }
        public DateTime? DateRecived { get; set; }
        public int? Unity { get; set; }

        public string UserOriginDescription { get { return UserOrigin.UserName; } }
        public string UserDestinyDescription { get { return UserDestiny.UserName; } }
        public string OfficeOriginDescription { get { return OfficeOrigin.Name; } }
        public string OfficeDestinyDescription { get { return OfficeDestiny.Name; } }

        public  UserDto UserOrigin { get; set; }
      
        public  UserDto UserDestiny { get; set; }
        
        public  OfficeDto OfficeOrigin { get; set; }
      
        public  OfficeDto OfficeDestiny { get; set; }
      
        public  Dispatch_StateDto State { get; set; }
        
        public  ICollection<StockDto> Stock { get; set; }
       // [NotMapped]
        public  ICollection<Dispatch_StockDto> Dispatch_stock { get; set; }
        public  string Code
        {
            get { return ID.ToString().PadLeft(10,'0'); }
           
        }

    }
}

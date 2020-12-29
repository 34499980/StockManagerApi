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
        public int Origin { get; set; }
        public int Destiny { get; set; }
        public int IdState { get; set; }
        public DateTime? DateDispatched { get; set; }
        public DateTime? DateRecived { get; set; }
        public int? Unity { get; set; }


     
        public  UserDto UsuarioOrigin { get; set; }
      
        public  UserDto UsuarioDestiny { get; set; }
        
        public  OfficeDto SucOrigin { get; set; }
      
        public  OfficeDto SucDestiny { get; set; }
      
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

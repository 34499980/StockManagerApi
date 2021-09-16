using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace DTO.Class
{
  
    public class HistoryDto: TablePropertiesDto
    {

        public int ID { get; set; }
        public DateTime DateProces { get; set; }
        public string UserName { get; set; }
        public int IdOffice{ get; set; }
        public string Action { get; set; }
        public string ActionDetail { get; set; }

        public  UserDto User{ get; set; }
      
     

    }
}

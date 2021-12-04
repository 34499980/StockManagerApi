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

        public long ID { get; set; }
        public DateTime DateProces { get; set; }      
        public string UserName { get { return User?.UserName; } }
        public string OfficeName { get { return Office?.Name; } }
        public int IdUser { get; set; }
        public int IdOffice{ get; set; }
        public int IdAction { get; set; }
        public string SubAction { get; set; }
        public string ActionDetail { get; set; }

        public  UserDto User{ get; set; }
        public OfficeDto Office { get; set; }
     

    }
}

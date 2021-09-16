using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Class
{
    public class HistoryFilterDto : TablePropertiesDto
    {      
        public string UserName { get; set; }
        public DateTime DateproccesFrom { get; set; }
        public DateTime DateproccesTo { get; set; }
        public string Action { get; set; }
       
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Class
{
    public class HistoryFilterDto : TablePropertiesDto
    {      
        public string UserName { get; set; }
        public DateTime? DateprocesFrom { get; set; }
        public DateTime? DateprocesTo { get; set; }
        public int? Action { get; set; }
        public int? IdOffice { get; set; }
       
    }
}

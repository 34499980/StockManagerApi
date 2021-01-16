using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO.Class
{
    public class Stock_OfficeDto
    {
     
        public int ID { get; set; }
        public int IdOffice { get; set; }
        public long IdStock { get; set; }
        public int Unity { get; set; }

       
        public virtual OfficeDto Office { get; set; }
    
        public virtual StockDto Stock { get; set; }

    }

}

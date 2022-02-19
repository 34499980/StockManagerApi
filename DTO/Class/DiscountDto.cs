using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Class
{
    public class DiscountDto
    {
        public long ID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int Percent { get; set; }
        public int IdPaymentType { get; set; }
        public long IdStock { get; set; }
        public int IdUser { get; set; }

       
        public virtual PaymentTypeDto PaymentType { get; set; }  
       
        public virtual StockDto Stock { get; set; }
      
        public virtual UserDto User { get; set; }
    }
}

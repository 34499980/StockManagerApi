using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Class
{
    public class DiscountPostDto
    {
        public long? ID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int Percent { get; set; }
        public int[] PaymentType { get; set; }
        public int[] officesIds { get; set; }
        public long? IdStock { get; set; }
        public bool Override { get; set; }
    }
}

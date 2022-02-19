using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Class
{
    public class DiscountFilterDto : TablePropertiesDto
    {
        public DateTime? CreateFrom { get; set; }
        public DateTime? CreateTo { get; set; }
        public int? PercentFrom { get; set; }
        public int? PercentTo { get; set; }
        public int? IdOffice { get; set; }
    }
}

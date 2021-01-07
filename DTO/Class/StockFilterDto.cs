using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Class
{
    public class StockFilterDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int? IdOffice { get; set; }
        public int? IdCountry { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Class
{
    public class StockPostDto: StockDto
    {
        public int IdCountry { get; set; }
        public dynamic Image { get; set; }
    }
}

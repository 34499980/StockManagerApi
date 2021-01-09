using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Class
{
    public class StockGetDto: StockDto
    {
        public string officeDescription { get { return Office.Name; } }
    }
}

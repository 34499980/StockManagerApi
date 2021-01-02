using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Class
{
    public class OfficeFilterDto
    {
        public string Name { get; set; }

        public int? IdCountry { get; set; }
        public bool Active { get; set; }
    }
}

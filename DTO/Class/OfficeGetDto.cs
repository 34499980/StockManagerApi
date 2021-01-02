using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Class
{
    public class OfficeGetDto : OfficeDto
    {
        public string CountryDescription { get { return Country.Description; } }
    }
}

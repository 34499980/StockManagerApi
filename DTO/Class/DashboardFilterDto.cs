using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Class
{
    public class DashboardFilterDto
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int? OfficeId { get; set; }
    }
}

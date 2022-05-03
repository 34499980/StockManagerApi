using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Class
{
    public class SaleFilterDto: TablePropertiesDto
    {
        public int? Id { get; set; }
        public string UserName { get; set; }
        public DateTime? DateProcesFrom { get; set; }
        public DateTime? DateProcesTo { get; set; }
        public int? IdUser { get; set; }
        public int? IdOffice { get; set; }
        public int? IdState { get; set; }
    }
}

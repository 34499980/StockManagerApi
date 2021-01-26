using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Class
{
    public class DispatchFilterDto
    {
        public string Code { get; set; }
        public string UserName { get; set; }
        public DateTime? CreatedDateFrom { get; set; }
        public DateTime? CreatedDateTo { get; set; }
        public DateTime? DispatchedDateFrom { get; set; }
        public DateTime? DispatchedDateTo { get; set; }
        public DateTime? RecceivedDateFrom { get; set; }
        public DateTime? ReceivedDateTo { get; set; }
        public int? IdState { get; set; }
        public int? IdDestiny { get; set; }
        public int? IdCountry { get; set; }
    }
}

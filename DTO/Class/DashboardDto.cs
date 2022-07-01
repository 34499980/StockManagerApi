using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Class
{
    public class DashboardDto
    {
        public List<DashboardDataDto> Data { get; set; }
        public string[] ColumnsName { get; set; }
    }
    public class DashboardDataDto
    {
        public string Label { get; set; }
        public int Count { get; set; }
    }
}

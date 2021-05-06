using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Class
{
    public class ResultDto<T>
    {
        public IList<T> data { get; set; }
        public int rowCount { get; set; }
    }
}

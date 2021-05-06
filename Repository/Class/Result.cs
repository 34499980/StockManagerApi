using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Class
{
    public class Result<T>
    {
        public IList<T> data { get; set; }
        public int rowCount { get; set; }
    }
}

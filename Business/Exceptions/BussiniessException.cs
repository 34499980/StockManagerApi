using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Exceptions
{
    public class BussiniessException : Exception
    {
        public string ErrorCode { get; set; }
        public int statusCode { get; set; }
    }
}

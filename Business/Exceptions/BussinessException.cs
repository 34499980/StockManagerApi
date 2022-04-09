using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Exceptions
{
    public class BussinessException : Exception
    {
        public BussinessException(string message)
       : base(message)
        {
          
        }
        public BussinessException(string message, int? code)
       : base(message)
        {
            if (code.HasValue)
                statusCode = code.Value;
           




        }
        public string ErrorCode { get; set; }
        public int statusCode { get; set; }
    }
}

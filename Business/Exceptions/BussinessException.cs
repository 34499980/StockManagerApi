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
        public string ErrorCode { get; set; }
        public int statusCode { get; set; }
    }
}

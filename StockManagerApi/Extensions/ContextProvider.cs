using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagerApi.Extensions
{
    public class ContextProvider
    {
        public static int SelectedCountry { get; set; }
        public static int UserId { get; set; }
        public static int RoleId { get; set; }
    }
}

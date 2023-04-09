using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetDeveloperTest.DTO
{
    public class OrderTotalsDTO
    {
        public decimal SubTotal { get; set; }

        public decimal Tax { get; set; }

        public decimal Shipping { get; set; }
        
    }
}
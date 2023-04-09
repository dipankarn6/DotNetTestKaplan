using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetDeveloperTest.DTO
{
    public class OrderSummaryDTO
    {
        public int OrderID { get; set; }
        public int OrderingPersonID { get; set; }
        public OrderTotalsDTO Totals { get; set; }
        public IEnumerable<int> OrderPersonIDs { get; set; }
    }
}
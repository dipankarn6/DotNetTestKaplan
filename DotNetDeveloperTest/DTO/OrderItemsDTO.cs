using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetDeveloperTest.DTO
{
    public class OrderItemsDTO
    {
        public int OrderID { get; set; }
        public IEnumerable<OrderItemDTO> Items { get; set; }
    }
}
using DotNetDeveloperTest.DTO;
using DotNetDeveloperTest.IS.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DotNetDeveloperTest.Services
{
    public class OrderSummaryService
    {
        public OrderSummaryService(TestDB testDB)
        {
            _testDB = testDB;
        }

        public async Task<OrderSummaryDTO> GetAsync(int orderID)
        {
            Order order = await _testDB.Orders
                .Where(o => o.OrderID == orderID)
                .Include(o => o.OrderItems).FirstOrDefaultAsync();

            OrderSummaryDTO summary = null;

            if (order != null)
            {
                summary = new OrderSummaryDTO()
                {
                    OrderID = orderID,
                    Totals = new OrderTotalsDTO()
                    {
                        Shipping = Shipping
                    }
                };

                List<int> personIDs = new List<int>();
                decimal subTotal = 0;
                foreach (OrderItem orderItem in order.OrderItems)
                {
                    personIDs.Add(orderItem.StudentPersonID);
                    subTotal += orderItem.Price;
                }

                summary.Totals.SubTotal = subTotal;
                summary.Totals.Tax = subTotal * TaxRate;
                summary.Totals.Shipping = Shipping;

                summary.OrderingPersonID = personIDs.First();

                summary.OrderPersonIDs = personIDs;
            }

            return summary;
        }

        private readonly TestDB _testDB;

        private const decimal TaxRate = 0.055m;
        private const decimal Shipping = 15.0m;
    }
}
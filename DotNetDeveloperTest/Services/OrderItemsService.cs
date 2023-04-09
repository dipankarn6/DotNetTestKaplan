using DotNetDeveloperTest.DTO;
using DotNetDeveloperTest.IS.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DotNetDeveloperTest.Services
{
    public class OrderItemsService : IOrderItemsService
    {
        public OrderItemsService(TestDB db)
        {
            _db = db;
        }

        public OrderItemsDTO Get(int orderID)
        {
            IEnumerable<OrderItem> orderItems = _db.OrderItems.Where(oi => oi.OrderID ==orderID);

            return new OrderItemsDTO()
            {
                OrderID = orderID,
                Items = orderItems.Select(oi => new OrderItemDTO()
                {
                    LineNumber = oi.LineNumber,
                    ProductID = oi.ProductID,
                    StudentPersonID = oi.StudentPersonID,
                    Price = oi.Price
                })
            };
        }

        public async Task<short> AddAsync(int orderID, OrderItemDTO item)
        {
            if (item.LineNumber != 0)
            {
                throw new ValidationException("LineNumber is generated and cannot be specified");
            }

            short lineNumber = (short)(_db.OrderItems.Where(oi => oi.OrderID == orderID).Max(oi => oi.LineNumber) + 1);

            _db.OrderItems.Add(new OrderItem()
            {
                OrderID = orderID,
                LineNumber = lineNumber,
                Price = item.Price,
                ProductID = item.ProductID,
                StudentPersonID = item.StudentPersonID
            });

            await _db.SaveChangesAsync();

            return lineNumber;
        }

        private TestDB _db;
    }
}
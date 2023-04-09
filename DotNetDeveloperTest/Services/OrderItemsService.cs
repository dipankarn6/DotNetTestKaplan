using DotNetDeveloperTest.DTO;
using DotNetDeveloperTest.IS.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Results;

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

            if (orderItems.Count(oi => oi.OrderID == orderID) == 0)
            {
                throw new Exception(HttpStatusCode.NotFound.ToString());
            }
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
                Quantity = item.Quantity,
                Price = item.Price,
                ProductID = item.ProductID,
                StudentPersonID = item.StudentPersonID
            });

            await _db.SaveChangesAsync();

            return lineNumber;
        }

        public int Delete(int OrderId, short LineNumber)
        {
            IEnumerable<OrderItem> orderItems = _db.OrderItems.Where(oi => oi.OrderID == OrderId);
            if (orderItems.Count(item =>  item.LineNumber == LineNumber) == 0)
            {
                throw new ValidationException($"Item with LineNumber {LineNumber} is not available");
            }
            foreach (var item in orderItems)
            {
                if(item.LineNumber == LineNumber)
                {
                    _db.OrderItems.Remove(item);
                }
            }

            _db.SaveChanges();
            return LineNumber;
        }

        private TestDB _db;
    }
}
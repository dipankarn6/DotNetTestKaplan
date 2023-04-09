using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DotNetDeveloperTest.DTO;
using DotNetDeveloperTest.Services;

namespace DotNetDeveloperTest.Controllers
{
    public class OrderItemsController : ApiController
    {
        public OrderItemsController(IOrderItemsService orderItemsService)
        {
            _orderItemsService = orderItemsService;
        }

        /// <summary>
        /// Get the items on the order
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        [Route("api/Orders/{orderID:int}/Items")]
        public OrderItemsDTO Get(int orderID)
        {
            try
            {
                return _orderItemsService.Get(orderID);
            }
            catch(Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage()
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.NotFound
                });
            }
        }

        /// <summary>
        /// Adds an item to an order, LineNumber must be zero or unspecified
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        [Route("api/Orders/{orderID:int}/Items")]
        public Task<short> Post(int orderID, OrderItemDTO item)
        {
            try
            {
                return _orderItemsService.AddAsync(orderID, item);
            }
            catch (ValidationException ve)
            {
                throw new HttpResponseException(new HttpResponseMessage()
                {
                    Content = new StringContent(ve.Message),
                    StatusCode = HttpStatusCode.BadRequest
                });
            }
        }

        /// <summary>
        /// Deletes an Item from the orders
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        [Route("api/Orders/{orderID:int}")]
        public int Delete(int orderID, short lineNumber)
        {
            try
            {
                return _orderItemsService.Delete(orderID, lineNumber);
            }
            catch (ValidationException ve)
            {
                throw new HttpResponseException(new HttpResponseMessage()
                {
                    Content = new StringContent(ve.Message),
                    StatusCode = HttpStatusCode.BadRequest
                });
            }
        }

        private readonly IOrderItemsService _orderItemsService;
    }
}

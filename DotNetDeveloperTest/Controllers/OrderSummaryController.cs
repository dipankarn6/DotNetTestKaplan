using DotNetDeveloperTest.DTO;
using DotNetDeveloperTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace DotNetDeveloperTest.Controllers
{
    public class OrderSummaryController : ApiController
    {
        public OrderSummaryController(OrderSummaryService orderSummaryService)
        {
            _orderSummaryService = orderSummaryService;
        }

        [Route("api/Orders/{orderID:int}/Summary")]
        public Task<OrderSummaryDTO> Get(int orderID)
        {
            return _orderSummaryService.GetAsync(orderID);
        }

        private readonly OrderSummaryService _orderSummaryService;
    }
}

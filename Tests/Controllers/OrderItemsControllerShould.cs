using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNetDeveloperTest.Controllers;
using DotNetDeveloperTest.Services;
using Moq;
using DotNetDeveloperTest.DTO;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net;

namespace Tests
{
    [TestClass]
    public class OrderItemsControllerShould
    {
        [TestInitialize]
        public void TestInitialize()
        {
            _testSubject = new OrderItemsController(_moqOrderItemsService.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public async Task ThrowHttpResponseExceptionWhenThereIsAValidationException()
        {
            _moqOrderItemsService.Setup(ois => ois.AddAsync(It.IsAny<int>(), It.IsAny<OrderItemDTO>()))
                .Throws(new ValidationException("test"));

            try
            {
                await _testSubject.Post(1, null);
            }
            catch(HttpResponseException ex)
            {
                Assert.IsNotNull(ex.Response);
                Assert.AreEqual(HttpStatusCode.BadRequest, ex.Response.StatusCode);
                throw;
            }
            
        }


        private OrderItemsController _testSubject;
        private Mock<IOrderItemsService> _moqOrderItemsService = new Mock<IOrderItemsService>();
    }
}

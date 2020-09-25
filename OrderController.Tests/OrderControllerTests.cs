using Xunit;
using CSharp.Controllers;
using CSharp.Models;
using static CSharp.Models.Order;
using CSharp.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace OrderController.Tests
{
    public class OrderControllerTests
    {
        [Fact]
        public void OrderController_ListAll_ReturnsStatusOkAndList()
        {
            IOrderManager orderManager = new OrderManager();
            OrderAPI _controller = new OrderAPI(orderManager);

            IActionResult _response = _controller.ListAllOrders();
            OkObjectResult _okObject = _response as OkObjectResult;
            List<Order> _results = _okObject.Value as List<Order>;

            Assert.NotNull(_response);
            Assert.Equal((int)HttpStatusCode.OK, _okObject.StatusCode);
            Assert.Equal(4, _results.Count);
        }

        [Fact]
        public void OrderController_CancelOrder_OrderNotFound()
        {
            IOrderManager orderManager = new OrderManager();
            OrderAPI _controller = new OrderAPI(orderManager);

            int _orderId = 123;

            IActionResult _response = _controller.CancelOrder(_orderId);
            NotFoundObjectResult _notFoundObject = _response as NotFoundObjectResult;

            Assert.NotNull(_response);
            Assert.Equal((int)HttpStatusCode.NotFound, _notFoundObject.StatusCode);
        }

        [Fact]
        public void OrderController_CancelOrder_OrderFound()
        {
            IOrderManager orderManager = new OrderManager();
            OrderAPI _controller = new OrderAPI(orderManager);

            int _orderId = 1;

            IActionResult _response = _controller.CancelOrder(_orderId);
            OkObjectResult _okObject = _response as OkObjectResult;

            Assert.NotNull(_response);
            Assert.Equal((int)HttpStatusCode.OK, _okObject.StatusCode);
        }

        [Fact]
        public void OrderController_UpdateOrder_ReturnUpdateOrderMessage()
        {
            IOrderManager orderManager = new OrderManager();
            OrderAPI _controller = new OrderAPI(orderManager);

            Order _order = new Order
            {
                Id = 123,
                Description = "test description",
                Price = 1.50,
                Status = OrderStatus.Active
            };

            string _response = _controller.UpdateOrder(_order);

            Assert.Equal("Order: 123 updated", _response);
        }

        [Fact]
        public void OrderController_CreateOrder_ReturnCreateOrderMessage()
        {
            IOrderManager orderManager = new OrderManager();
            OrderAPI _controller = new OrderAPI(orderManager);

            Order _order = new Order
            {
                Id = 123,
                Description = "test description",
                Price = 1.50,
                Status = OrderStatus.Active
            };

            string _response = _controller.CreateOrder(_order);

            Assert.Equal("Order: 123 created", _response);
        }


    }
}

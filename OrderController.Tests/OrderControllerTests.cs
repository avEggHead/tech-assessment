using Xunit;
using CSharp.Controllers;
using CSharp.Models;
using static CSharp.Models.Order;

namespace OrderController.Tests
{
    public class OrderControllerTests
    {
        [Fact]
        public void OrderController_ListAll_ReturnListAllMessage()
        {
            OrderAPI _controller = new OrderAPI();

            string _response = _controller.ListAllOrders();

            Assert.Equal("All Orders: ...", _response);
        }

        [Fact]
        public void OrderController_UpdateOrder_ReturnUpdateOrderMessage()
        {
            OrderAPI _controller = new OrderAPI();

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
            OrderAPI _controller = new OrderAPI();

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

        [Fact]
        public void OrderController_CancelOrder_ReturnCancelOrderMessage()
        {
            OrderAPI _controller = new OrderAPI();

            int _orderId = 123;

            string _response = _controller.CancelOrder(_orderId);

            Assert.Equal("Order: 123 canceled", _response);
        }
    }
}

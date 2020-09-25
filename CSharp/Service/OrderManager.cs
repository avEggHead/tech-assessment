using CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Service
{
    public class OrderManager : IOrderManager
    {
        private List<Order> Orders => new List<Order>() {
            new Order {Id = 1, Description = "Order 1", Price = 1.51, Status = Order.OrderStatus.Active},
            new Order {Id = 2, Description = "Order 2", Price = 3.51, Status = Order.OrderStatus.Active},
            new Order {Id = 3, Description = "Order 3", Price = 2.09, Status = Order.OrderStatus.Active},
            new Order {Id = 4, Description = "Order 4", Price = 7.25, Status = Order.OrderStatus.Active},
        };


        public Response CancelOrder(int orderId)
        {
            Response _response = new Response() { IsSuccess = true};
            Order order = this.Orders.Where(o => o.Id == orderId).FirstOrDefault();
            
            if (order!= null)
            {
                order.Status = Order.OrderStatus.Inactive;
                _response.Message = $"Order canceled. Order {orderId} status: {order.Status}";    
            }
            else
            {
                _response.Message = $"An order with id {orderId} wasn't found";
                _response.IsSuccess = false;
            }

            return _response;
        }

        public List<Order> GetAllOrders()
        {
            return this.Orders;
        }
    }
}

using CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Service
{
    public interface IOrderManager
    {
        List<Order> GetAllOrders();

        Response CancelOrder(int orderId);
    }
}

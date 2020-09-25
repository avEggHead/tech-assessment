using CSharp.Models;
using CSharp.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSharp.Controllers
{
	[ApiController]
	[Route("order")]
	public class OrderAPI : ControllerBase
	{

		private IOrderManager _orderManager = null;

		public OrderAPI(IOrderManager orderManager)
		{
			this._orderManager = orderManager;
		}

		[HttpGet]
		[Route("listall")]
		public IActionResult ListAllOrders()
		{
			List<Order> _allOrders = this._orderManager.GetAllOrders();
			return Ok(_allOrders);
		}

		[HttpPost]
		[Route("update")]
		public string UpdateOrder([FromBody] Order order)
		{
			return $"Order: {order.Id} updated";
		}

		[HttpPost]
		[Route("create")]
		public string CreateOrder([FromBody] Order order)
		{
			return $"Order: {order.Id} created";
		}

		[HttpPost]
		[Route("cancel")]
		public IActionResult CancelOrder([FromQuery] int orderId)
		{
			Response _response = this._orderManager.CancelOrder(orderId);
			if (_response.IsSuccess)
			{
				return Ok(_response);
			}
			else
			{
				return NotFound(_response);
			}
		}
	}

}

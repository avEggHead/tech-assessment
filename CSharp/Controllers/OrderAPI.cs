using CSharp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSharp.Controllers
{
	[ApiController]
	[Route("order")]
	public class OrderAPI : ControllerBase
	{		
		[HttpGet]
		[Route("listall")]
		public string ListAllOrders()
		{
			return "All Orders: ...";
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
		public string CancelOrder([FromQuery] int orderId)
		{
			return $"Order: {orderId} canceled";
		}
	}

}

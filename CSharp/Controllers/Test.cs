namespace CSharp.Controllers
{
using Microsoft.AspNetCore.Mvc;

	[ApiController]
	[Route("[controller]")]
	public class Test : ControllerBase
	{ 
		[HttpGet]
		public string Get()
		{
			return "Gnarly!";
		}
	}
}

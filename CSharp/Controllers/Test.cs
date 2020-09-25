using Microsoft.AspNetCore.Mvc;


namespace CSharp.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class Test : ControllerBase
	{ 
		[HttpGet]
		public string Get()
		{
			return "Success!";
		}
	}
}

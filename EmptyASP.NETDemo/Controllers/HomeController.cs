using Microsoft.AspNetCore.Mvc;

namespace MyApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMessage()
        {
            var data = new
            {
                Message = "Hello from ASP.NET Core MVC without Views!",
                Timestamp = DateTime.Now
            };

            return Ok(data); // Return JSON data
        }
    }
}

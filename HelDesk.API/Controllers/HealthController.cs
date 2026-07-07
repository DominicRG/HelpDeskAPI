using HelpDesk.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HelDesk.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<string> errors = new List<string>();
            errors.Add("primer error");
            errors.Add("segundo error");

            var response1 = ApiResponseFactory.Success<string>("API ONLINE", "HelpDesk API funcionando correctamente.");
            var response2 = ApiResponseFactory.Failure<string>("HelpDesk API funcionando correctamente.", errors);
            return Ok(response1);
        }
    }
}

using HelpDesk.Application.Area.Services.Interfaces;
using HelpDesk.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HelDesk.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _service;

        public AreaController(IAreaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var areas = await _service.GetAllAsync();

            return Ok(ApiResponseFactory.Success(areas, "Áreas obtenidas correctamente"));
        }
    }
}

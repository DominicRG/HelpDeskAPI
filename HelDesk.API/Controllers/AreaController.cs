using HelpDesk.Application.Area.DTOs;
using HelpDesk.Application.Area.Services.Interfaces;
using HelpDesk.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HelDesk.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _service;

        public AreaController(IAreaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var areas = await _service.GetAllAsync();

            return Ok(ApiResponseFactory.Success(areas, "Áreas obtenidas correctamente"));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateAreaRequest request)
        {
            var id = await _service.CreateAsync(request);

            return Ok(ApiResponseFactory.Success(id, "Área registrada correctamente"));
        }
    }
}

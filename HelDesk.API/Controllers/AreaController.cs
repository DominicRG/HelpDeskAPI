using HelpDesk.Application.Area.DTOs;
using HelpDesk.Application.Area.Services.Interfaces;
using HelpDesk.Shared.Constants;
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

            return Ok(ApiResponseFactory.Success(areas, EntityMessages.GetAll(EntityNames.Areas)));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var area = await _service.GetByIdAsync(id);

            if(area == null)
            {
                return NotFound(ApiResponseFactory.Failure<string>(EntityMessages.NotFound(EntityNames.Area)));
            }
            
            return Ok(ApiResponseFactory.Success(area, EntityMessages.Get(EntityNames.Area)));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateAreaRequest request)
        {
            var id = await _service.CreateAsync(request);

            return Ok(ApiResponseFactory.Success(id, EntityMessages.Created(EntityNames.Area)));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateAreaRequest request)
        {
            await _service.UpdateAsync(id, request);

            return Ok(ApiResponseFactory.Success(true, EntityMessages.Created(EntityNames.Area)));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Ok(ApiResponseFactory.Success(id, EntityMessages.Deleted(EntityNames.Area)));
        }
    }
}

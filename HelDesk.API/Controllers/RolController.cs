using HelpDesk.Application.Rol.DTOs;
using HelpDesk.Application.Rol.Services.Interfaces;
using HelpDesk.Domain.Entities;
using HelpDesk.Shared.Constants;
using HelpDesk.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HelDesk.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        private readonly IRolService _service;

        public RolController(IRolService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _service.GetAllAsync();
            return Ok(ApiResponseFactory.Success(roles, EntityMessages.GetAll(EntityNames.Rol)));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rol = await _service.GetByIdAsync(id);
            return Ok(ApiResponseFactory.Success(rol, EntityMessages.Get(EntityNames.Rol)));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRolRequest createRolRequest)
        {
            var id = await _service.CreateAsync(createRolRequest);
            return Ok(ApiResponseFactory.Success(id, EntityMessages.Created(EntityNames.Rol)));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRolRequest updateRolRequest)
        {
            await _service.UpdateAsync(id, updateRolRequest);
            return Ok(ApiResponseFactory.Success(id, EntityMessages.Updated(EntityNames.Rol)));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok(ApiResponseFactory.Success(id, EntityMessages.Deleted(EntityNames.Rol)));
        }
    }
}

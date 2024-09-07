using BLL.Abstract;
using DTO.RoleDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles ="Superadmin")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServices _services;
        public RoleController(IRoleServices services)
        {
            _services = services;
        }

        [AllowAnonymous]
        [HttpGet("{RoleId}")]
        public async Task<IActionResult> Get(Guid RoleId)
        {
            var data = await _services.GetAsync(RoleId);
            return Ok(data);
        }

        [AllowAnonymous]
        [HttpGet("get-all")]
        public async Task<IActionResult> Get()
        {
            var data = await _services.GetAll();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoleToAddDto dto)
        {
            await _services.AddAsync(dto);
            return Ok("Created");
        }

        [HttpDelete("{RoleId}")]
        public async Task<IActionResult> Delete(Guid RoleId)
        {
            await _services.Delete(RoleId);
            return Ok("Deleted");
        }
    }
}

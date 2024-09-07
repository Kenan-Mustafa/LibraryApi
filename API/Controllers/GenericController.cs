using BLL.Abstract;
using DTO.AuthorDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController : ControllerBase
    {
        private readonly IGenericAuthorService _services;
        public GenericController(IGenericAuthorService services)
        {
            _services = services;
        }

        [HttpGet("{AuthorId}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid AuthorId)
        {
            var data = await _services.GetAsync(AuthorId);
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
        [ServiceFilter(typeof(ValidationFilter<AuthorToAddDto>))]
        public async Task<IActionResult> Post([FromBody] AuthorToAddDto dto)
        {
            await _services.AddAsync(dto);
            return Ok("Created");
        }
        [Authorize(Roles = "Superadmin")]
        [HttpDelete("{AuthorId}")]
        public async Task<IActionResult> Delete(Guid AuthorId)
        {
            await _services.Delete(AuthorId);
            return Ok("Deleted");
        }
    }
}

using BLL.Abstract;
using DTO.AuthorDTOs;
using DTO.UserDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorServices _services;
        public AuthorController(IAuthorServices services)
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

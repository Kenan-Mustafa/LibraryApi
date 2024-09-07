using BLL.Abstract;
using DTO.MemberDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class MemberController : ControllerBase
    {
        private readonly IMemberServices _services;
        public MemberController(IMemberServices services)
        {
            _services = services;
        }

        [HttpGet("{MemberId}")]
        public async Task<IActionResult> Get(Guid MemberId)
        {
            var data = await _services.GetAsync(MemberId);
            return Ok(data);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> Get()
        {
            var data = await _services.GetAll();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MemberToAddDto dto)
        {
            await _services.AddAsync(dto);
            return Ok("Created");
        }

        [HttpDelete("{MemberId}")]
        public async Task<IActionResult> Delete(Guid MemberId)
        {
            await _services.Delete(MemberId);
            return Ok("Deleted");
        }
    }
}

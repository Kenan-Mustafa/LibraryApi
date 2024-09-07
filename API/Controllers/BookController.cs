using BLL.Abstract;
using DTO.BookDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _services;
        public BookController(IBookServices services)
        {
            _services = services;
        }
        [HttpGet("{BookId}")]
        public async Task<IActionResult> Get(Guid BookId)
        {
            var data = await _services.GetAsync(BookId);
            return Ok(data);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> Get()
        {
            var data = await _services.GetAll();
            return Ok(data);
        }

        [HttpPost]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilter<BookToAddDto>))]
        public async Task<IActionResult> Post([FromBody] BookToAddDto dto)
        {
            await _services.AddAsync(dto);
            return Ok("Created");
        }

        [Authorize]
        [HttpDelete("{BookId}")]
        public async Task<IActionResult> Delete(Guid BookId)
        {
            await _services.Delete(BookId);
            return Ok("Deleted");
        }
    }
}

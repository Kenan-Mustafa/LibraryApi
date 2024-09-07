using BLL.Abstract;
using DTO.LoanDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanServices _services;
        public LoanController(ILoanServices services)
        {
            _services = services;
        }

        [HttpGet("{LoanId}")]
        [Authorize]
        public async Task<IActionResult> Get(Guid LoanId)
        {
            var data = await _services.GetAsync(LoanId);
            return Ok(data);
        }

        [HttpGet("get-all")]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var data = await _services.GetAll();
            return Ok(data);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] LoanToAddDto dto)
        {
            await _services.AddAsync(dto);
            return Ok("Created");
        }

        [HttpDelete("{LoanId}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid LoanId)
        {
            await _services.Delete(LoanId);
            return Ok("Deleted");
        }
    }
}

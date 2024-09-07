using BLL.Abstract;
using BLL.Concrete;
using DTO.UserDTOs;
using DTO.UserDTOs;
using Entity;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using System;
using Validation;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private IValidator<UserToAddDto> _validator;
        private IUserServices _services;
        public UserController(IUserServices services, IValidator<UserToAddDto> validator)
        {
            _services = services;
            _validator = validator;
        }

        [HttpGet("{UserId}")]
        public async Task<IActionResult> Get(Guid UserId)
        {
            var data = await _services.GetAsync(UserId);
            return Ok(data);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> Get()
        {
            var data = await _services.GetAll();
            return Ok(data);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilter<UserToAddDto>))]
        public async Task<IActionResult> Post([FromBody] UserToAddDto dto)
        {
            await _services.AddAsync(dto);
            Log.Information("User created successfully with Name: {FullName}", dto.Username);
            var response = new
            {
                StatusCode = 200,
                Message = "Created",
                TraceId = HttpContext.TraceIdentifier
            };

            return Ok(response);

        }

        [HttpDelete("{UserId}")]
        public async Task<IActionResult> Delete(Guid UserId)
        {
            await _services.Delete(UserId);
            return Ok("Deleted");
        }
    }
}

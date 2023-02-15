using Finances.Domain.DTOs;
using Finances.Domain.Entities.Models;
using Finances.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Finances.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        ///<summary>
        ///Cadastrar novo usuário
        ///</summary>
        ///<param name="request">Objeto de cadastro de novo usuário</param>
        ///<response code="201">Cdastrado com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody][Required]UserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userService.AddAsync(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<ActionResult<User>> Get([Required] int id)
        {
            var response = await _userService.GetByIdAsync(id);

            if (response == null)
            {
                return NoContent();
            }

            return Ok(response);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Strab.Domain.Entities;
using Strab.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Strab.Domain.Api.Services;
using Strab.Domain.Api.Models;

namespace Strab.Domain.Api.Controllers;

[ApiController]
[Route("v1/users")]
[Authorize]
public class UsersController : ControllerBase
{
    [HttpGet(Name = "")]
    [Authorize(Roles = "ADM")]
    public async Task<ActionResult<IEnumerable<User>>> GetAll([FromServices] IUserRepository userRepository)
    {
        var users = await userRepository.GetAll();
        return Ok(users);
    }

    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> Authenticate(
                    [FromServices] IUserRepository userRepository,
                    [FromBody] UserLogin model)
    {
        var user = await userRepository.Login(model.Email, model.Password);

        if (user == null)
            return NotFound(new { message = "Usuário e/ou senha inválidos" });

        var token = TokenService.GenerateToken(user);
        // Esconde a senha
        user.ClearPassword();

        return Ok(new
        {
            user = user,
            token = token
        });
    }
}

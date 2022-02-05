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
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "")]
    [Authorize(Roles = "ADM")]
    public IEnumerable<User> GetAll([FromServices] IUserRepository userRepository)
    {
        return userRepository.GetAll();
    }

    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public ActionResult<dynamic> Authenticate(
                    [FromServices] IUserRepository userRepository,
                    [FromBody] UserLogin model)
    {
        var user = userRepository.Login(model.Email, model.Password);

        if (user == null)
            return NotFound(new { message = "Usuário e/ou senha inválidos" });

        var token = TokenService.GenerateToken(user);
        // Esconde a senha
        user.ClearPassword();

        return new
        {
            user = user,
            token = token
        };
    }
}

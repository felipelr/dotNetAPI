using Microsoft.AspNetCore.Mvc;
using Strab.Domain.Entities;
using Strab.Domain.Repositories;

namespace Strab.Domain.Api.Controllers;

[ApiController]
[Route("v1/users")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "")]
    public IEnumerable<User> GetAll([FromServices] IUserRepository userRepository)
    {
        return userRepository.GetAll();
    }
}

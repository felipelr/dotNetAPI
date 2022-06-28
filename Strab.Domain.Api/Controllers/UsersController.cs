using Microsoft.AspNetCore.Mvc;
using Strab.Domain.Entities;
using Strab.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Strab.Domain.Api.Services;
using Strab.Domain.Api.Models;
using Strab.Domain.Handlers;
using Strab.Domain.Commands.Users;
using Strab.Domain.Commands;
using Strab.Domain.Mappers.Interfaces;
using Strab.Domain.Dtos;

namespace Strab.Domain.Api.Controllers;

[ApiController]
[Route("v1/users")]
[Authorize]
public class UsersController : ControllerBase
{
    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> Authenticate(
                    [FromServices] IUserRepository userRepository,
                    [FromServices] IClientRepository clientRepository,
                    [FromServices] IProfessionalRepository professinalRepository,
                    [FromServices] IMapperConfig mapper,
                    [FromBody] UserLogin model)
    {
        var user = await userRepository.Login(model.Email, model.Password);

        if (user == null)
            return NotFound(new { message = "Usuário e/ou senha inválidos" });

        var token = TokenService.GenerateToken(user);

        var userDTO = mapper.GetMapper().Map<UserDTO>(user);
        if (userDTO != null)
        {
            userDTO.Client = mapper.GetMapper().Map<ClientDTO>(await clientRepository.GetByUserId(userDTO.Id));
            userDTO.Professional = mapper.GetMapper().Map<ProfessionalDTO>(await professinalRepository.GetByUserId(userDTO.Id));
        }

        return Ok(new
        {
            user = userDTO,
            token = token
        });
    }

    [HttpGet]
    [Authorize(Roles = "ADM")]
    public async Task<ActionResult<IEnumerable<User>>> GetAll([FromServices] IUserRepository userRepository)
    {
        var users = await userRepository.GetAll();
        Console.WriteLine("Users - " + users.Count());
        return Ok(users);
    }

    [HttpPost]
    [Authorize(Roles = "ADM")]
    public async Task<ActionResult<dynamic>> Create(
                    [FromServices] CreateUserHandler createUserHandler,
                    [FromBody] CreateUserCommand createUserCommand)
    {

        if (createUserCommand == null)
            return BadRequest(new { message = "Informações inválidas" });

        var result = (GenericCommandResult)await createUserHandler.Handle(createUserCommand);

        return Ok(result);
    }
}

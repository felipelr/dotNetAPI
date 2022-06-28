using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strab.Domain.Api.Controllers;
using Strab.Domain.Api.Models;
using Strab.Domain.Tests.Repositories;
using Strab.Domain.Commands.Users;
using Strab.Domain.Handlers;
using Moq;
using Strab.Domain.Repositories;
using Strab.Domain.Entities;
using Strab.Domain.Mappers;

namespace Strab.Domain.Tests.ControllerTests;

[TestClass]
public class UserControllerTests
{
    private readonly CreateUserCommand _validCreateUserProfessionalCommand;
    private readonly CreateUserCommand _validCreateUserClientCommand;
    private readonly IList<User> _users;

    public UserControllerTests()
    {
        _validCreateUserClientCommand = new CreateUserCommand("João", "42516423844", DateTime.Now.AddYears(-28), "MASCULINO", "", "18997642035", "", "", "joao.fake@gmail.com", "1234567890", "", "", "", "", "client");
        _validCreateUserProfessionalCommand = new CreateUserCommand("Carlos", "42516423844", DateTime.Now.AddYears(-28), "MASCULINO", "", "18997642035", "", "", "carlos.fake@gmail.com", "1234567890", "", "", "", "", "professional");
        _users = new List<User>();
        _users.Add(new User(1, "felipe@fake.com", "", "", "", true, DateTime.Now, DateTime.Now, new Role(1, "adm", "adm"), "android", "29"));
    }

    [TestMethod]
    public async Task DadoUmConsultaDeveRetornarStatus200()
    {
        var mock = new Mock<IUserRepository>();
        mock.Setup(x => x.GetAll()).Returns(Task.FromResult<IEnumerable<User>>(_users));

        var sut = new UsersController();
        var actionResult = await sut.GetAll(mock.Object);
        var result = actionResult.Result as OkObjectResult;
        var resultData = result?.Value as IList<User>;

        Assert.AreEqual(result?.StatusCode, 200);
        Assert.AreEqual(resultData?.Count, 1);
    }

    [TestMethod]
    public async Task DadoAutenticacaoDeveRetornarStatus200()
    {
        var userRepository = new FakeUserRepository();
        var clientRepository = new FakeClientRepository();
        var professinalRepository = new FakeProfessionalRepository();
        var mapper = new StrabMapperConfig();

        var userModel = new UserLogin()
        {
            Email = "felipe.lima.flr@gmail.com",
            Password = "1234567890",
        };
        var sut = new UsersController();
        var actionResult = await sut.Authenticate(userRepository, clientRepository, professinalRepository, mapper, userModel);
        var result = actionResult.Result as OkObjectResult;
        Assert.AreEqual(result?.StatusCode, 200);
    }

    [TestMethod]
    public async Task DadoCriacaoUsuarioProfissionalDeveRetornarStatus200()
    {
        var userRepository = new FakeUserRepository();
        var roleRepository = new FakeRoleRepository();
        var clientRepository = new FakeClientRepository();
        var professionalRepository = new FakeProfessionalRepository();
        var createUserHandler = new CreateUserHandler(userRepository, roleRepository, clientRepository, professionalRepository);

        var sut = new UsersController();
        var actionResult = await sut.Create(createUserHandler, _validCreateUserProfessionalCommand);
        var result = actionResult.Result as OkObjectResult;
        Assert.AreEqual(result?.StatusCode, 200);
    }

    [TestMethod]
    public async Task DadoCriacaoUsuarioClientDeveRetornarStatus200()
    {
        var userRepository = new FakeUserRepository();
        var roleRepository = new FakeRoleRepository();
        var clientRepository = new FakeClientRepository();
        var professionalRepository = new FakeProfessionalRepository();
        var createUserHandler = new CreateUserHandler(userRepository, roleRepository, clientRepository, professionalRepository);

        var sut = new UsersController();
        var actionResult = await sut.Create(createUserHandler, _validCreateUserClientCommand);
        var result = actionResult.Result as OkObjectResult;
        Assert.AreEqual(result?.StatusCode, 200);
    }
}
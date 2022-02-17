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

namespace Strab.Domain.Tests.ControllerTests;

[TestClass]
public class UserControllerTests
{
    private readonly CreateUserCommand _validCreateUserProfessionalCommand = new CreateUserCommand(
            "Carlos",
            "42516423844",
            DateTime.Now.AddYears(-28),
            "MASCULINO",
            "",
            "18997642035",
            "",
            "",
            "carlos.fake@gmail.com",
            "1234567890",
            "",
            "",
            "",
            "",
            "professional");

    private readonly CreateUserCommand _validCreateUserClientCommand = new CreateUserCommand(
    "João",
    "42516423844",
    DateTime.Now.AddYears(-28),
    "MASCULINO",
    "",
    "18997642035",
    "",
    "",
    "joao.fake@gmail.com",
    "1234567890",
    "",
    "",
    "",
    "",
    "client");

    [TestMethod]
    public async Task DadoUmConsultaDeveRetornarStatus200()
    {
        var userRepository = new FakeUserRepository();
        var sut = new UsersController();
        var actionResult = await sut.GetAll(userRepository);
        var result = actionResult.Result as OkObjectResult;
        Assert.AreEqual(result?.StatusCode, 200);
    }

    [TestMethod]
    public async Task DadoAutenticacaoDeveRetornarStatus200()
    {
        var userRepository = new FakeUserRepository();
        var userModel = new UserLogin()
        {
            Email = "felipe.lima.flr@gmail.com",
            Password = "1234567890",
        };
        var sut = new UsersController();
        var actionResult = await sut.Authenticate(userRepository, userModel);
        var result = actionResult.Result as OkObjectResult;
        Assert.AreEqual(result?.StatusCode, 200);
    }

    [TestMethod]
    public void DadoCriacaoUsuarioProfissionalDeveRetornarStatus200()
    {
        var userRepository = new FakeUserRepository();
        var roleRepository = new FakeRoleRepository();
        var clientRepository = new FakeClientRepository();
        var professionalRepository = new FakeProfessionalRepository();
        var createUserHandler = new CreateUserHandler(userRepository, roleRepository, clientRepository, professionalRepository);

        var sut = new UsersController();
        var actionResult = sut.Create(createUserHandler, _validCreateUserProfessionalCommand);
        var result = actionResult.Result as OkObjectResult;
        Assert.AreEqual(result?.StatusCode, 200);
    }

    [TestMethod]
    public void DadoCriacaoUsuarioClientDeveRetornarStatus200()
    {
        var userRepository = new FakeUserRepository();
        var roleRepository = new FakeRoleRepository();
        var clientRepository = new FakeClientRepository();
        var professionalRepository = new FakeProfessionalRepository();
        var createUserHandler = new CreateUserHandler(userRepository, roleRepository, clientRepository, professionalRepository);

        var sut = new UsersController();
        var actionResult = sut.Create(createUserHandler, _validCreateUserClientCommand);
        var result = actionResult.Result as OkObjectResult;
        Assert.AreEqual(result?.StatusCode, 200);
    }
}
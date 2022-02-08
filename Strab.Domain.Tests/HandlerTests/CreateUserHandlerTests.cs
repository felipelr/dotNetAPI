using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strab.Domain.Commands;
using Strab.Domain.Commands.Users;
using Strab.Domain.Handlers;
using Strab.Domain.Tests.Repositories;

namespace Strab.Domain.Tests.CommandTests;

[TestClass]
public class CreateUserHandlerTests
{
    private readonly CreateUserCommand _invalidCommand = new CreateUserCommand(new DTOs.Users.CreateUserDTO());
    private readonly CreateUserCommand _validCommand = new CreateUserCommand(new DTOs.Users.CreateUserDTO(
        "Felipe",
        "42516423844",
        DateTime.Now.AddYears(-28),
        "MASCULINO",
        "",
        "18997642035",
        "",
        "",
        "felipe.fake@gmail.com",
        "1234567890",
        "",
        "",
        2,
        "",
        "",
        "professional"));

    private readonly CreateUserHandler handler = new CreateUserHandler(
        new FakeUserRepository(),
        new FakeRoleRepository(),
        new FakeClientRepository(),
        new FakeProfessionalRepository());

    public CreateUserHandlerTests()
    {
        _invalidCommand.Validate();
        _validCommand.Validate();
    }

    [TestMethod]
    public void DadoUmComandoInvalidoDeveInterromperarAExecucao()
    {
        var result = (GenericCommandResult)handler.Handle(_invalidCommand);
        Assert.AreEqual(result.Success, false);
    }

    [TestMethod]
    public void DadoUmComandoValidoDeveCriarOUsuario()
    {
        var result = (GenericCommandResult)handler.Handle(_validCommand);
        Assert.AreEqual(result.Success, true);
    }
}
using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strab.Domain.Commands;
using Strab.Domain.Commands.Users;
using Strab.Domain.Handlers;
using Strab.Domain.Tests.Repositories;

namespace Strab.Domain.Tests.HandlerTests;

[TestClass]
public class CreateUserHandlerTests
{
    private readonly CreateUserCommand _invalidCommand = new CreateUserCommand();
    private readonly CreateUserCommand _validCommand = new CreateUserCommand(
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
        "",
        "",
        "professional");

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
    public async Task DadoUmComandoInvalidoDeveInterromperarAExecucao()
    {
        var result = (GenericCommandResult)await handler.Handle(_invalidCommand);
        Assert.AreEqual(result.Success, false);
    }

    [TestMethod]
    public async Task DadoUmComandoValidoDeveCriarOUsuario()
    {
        var result = (GenericCommandResult)await handler.Handle(_validCommand);
        Assert.AreEqual(result.Success, true);
    }
}
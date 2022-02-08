using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strab.Domain.Commands.Users;

namespace Strab.Domain.Tests.CommandTests;

[TestClass]
public class CreateUserCommandTests
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

    public CreateUserCommandTests()
    {
        _invalidCommand.Validate();
        _validCommand.Validate();
    }

    [TestMethod]
    public void DadoUmComandoInvalido()
    {
        Assert.AreEqual(_invalidCommand.IsValid, false);
    }

    [TestMethod]
    public void DadoUmComandoValido()
    {
        Assert.AreEqual(_validCommand.IsValid, true);
    }
}
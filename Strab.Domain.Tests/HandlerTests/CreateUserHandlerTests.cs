using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strab.Domain.Commands.Users;

namespace Strab.Domain.Tests.CommandTests;

[TestClass]
public class CreateUserHandlerTests
{
    public CreateUserHandlerTests()
    {

    }

    [TestMethod]
    public void DadoUmComandoInvalidoDeveInterromperarAExecucao()
    {
        Assert.Fail();
    }

    [TestMethod]
    public void DadoUmComandoValidoDeveCriarOUsuario()
    {
        Assert.Fail();
    }
}
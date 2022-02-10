using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strab.Domain.Api.Controllers;
using Strab.Domain.Entities;
using Strab.Domain.Tests.Repositories;

namespace Strab.Domain.Tests.ControllerTests;

[TestClass]
public class UserControllerTests
{

    [TestMethod]
    public void DadoUmConsultaDeveRetornarStatus200()
    {
        FakeUserRepository userRepository = new FakeUserRepository();
        var sut = new UsersController();
        var result = sut.GetAll(userRepository);
        var users = result.Result.Result as IList<User>;

        Assert.AreEqual(users, null);
    }
}
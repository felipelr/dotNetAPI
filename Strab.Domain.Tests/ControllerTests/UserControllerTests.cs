using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strab.Domain.Api.Controllers;
using Strab.Domain.Entities;
using Strab.Domain.Tests.Repositories;

namespace Strab.Domain.Tests.ControllerTests;

[TestClass]
public class UserControllerTests
{

    [TestMethod]
    public async Task DadoUmConsultaDeveRetornarStatus200()
    {
        FakeUserRepository userRepository = new FakeUserRepository();
        var sut = new UsersController();
        var result = await sut.GetAll(userRepository);
        var users = result.Value as List<User>;
        Assert.AreEqual(users, null);
    }
}
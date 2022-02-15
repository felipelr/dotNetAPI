using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strab.Domain.Api.Controllers;
using Strab.Domain.Api.Models;
using Strab.Domain.Entities;
using Strab.Domain.Tests.Repositories;

namespace Strab.Domain.Tests.ControllerTests;

[TestClass]
public class UserControllerTests
{

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
}
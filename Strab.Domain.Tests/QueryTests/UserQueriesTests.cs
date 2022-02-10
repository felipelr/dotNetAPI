using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strab.Domain.Entities;
using Strab.Domain.Queries;

namespace Strab.Domain.Tests.QueryTests;

[TestClass]
public class UserQueriesTests
{
    private List<User> _usuarios;

    public UserQueriesTests()
    {
        _usuarios = new List<User>();
        _usuarios.Add(new User(
            1,
            "felipe.adm@gmail.com",
            "1234567890",
            "",
            "",
            true,
            DateTime.Now,
            DateTime.Now,
            new Role(1, "adm", "adm"),
            "android",
            "29"
        ));
        _usuarios.Add(new User(
            2,
            "felipe.client@gmail.com",
            "1234567890",
            "",
            "",
            true,
            DateTime.Now,
            DateTime.Now,
            new Role(2, "client", "client"),
            "android",
            "29"
        ));
        _usuarios.Add(new User(
            3,
            "felipe.professional@gmail.com",
            "1234567890",
            "",
            "",
            true,
            DateTime.Now,
            DateTime.Now,
            new Role(3, "professional", "professional"),
            "android",
            "29"
        ));
        _usuarios.Add(new User(
            4,
            "felipe.professional@gmail.com",
            "1234567890",
            "",
            "",
            false,
            DateTime.Now,
            DateTime.Now,
            new Role(3, "professional", "professional"),
            "android",
            "29"
        ));
    }

    [TestMethod]
    public void DadoUmaConsultaDeveRetornarApenasUsuarioDaFuncaoEspecificada()
    {
        var result = _usuarios.AsQueryable().Where(UserQueries.GetByRole(1));
        Assert.AreEqual(1, result.Count());
    }

    [TestMethod]
    public void DadoUmaConsultaDeveRetornarApenasUsuarioAtivos()
    {
        var result = _usuarios.AsQueryable().Where(UserQueries.GetAllActive());
        Assert.AreEqual(3, result.Count());
    }
}
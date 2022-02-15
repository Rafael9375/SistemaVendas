using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaVendas.Core;
using SistemaVendas.Core.DAL;
using SistemaVendas.Core.TO;

namespace TesteUnitario
{
    [TestClass]
    public class ContextTest
    {
        [TestMethod]
        public void TestInsertUsuario()
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            UsuarioTO usuario = new UsuarioTO();
            usuario.Nome = "Rafael";
            usuario.RG = "132";
            usuario.Senha = "123";
            usuario.Telefone = "123";
            usuario.DesLogin = "asdasdasd";
            usuario.CPF = "123";
            usuarioDAL.Insert(usuario);
        }
    }
}

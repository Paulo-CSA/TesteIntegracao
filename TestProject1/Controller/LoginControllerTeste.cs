using Castle.Components.DictionaryAdapter.Xml;
using Chapter.Controllers;
using Chapter.Interfaces;
using Chapter.Models;
using Chapter.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Controller
{
    public class LoginControllerTeste
    {
        [Fact]
        public void LoginControllerRetornar_UsuarioInvalido()
        {
            //preparação
            var fakeRepository = new Mock<IUsuarioRepository>();
            fakeRepository.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns((Usuario)null);

            LoginViewModels dadosLogin = new LoginViewModels();
            dadosLogin.Email = "email@email.com";
            dadosLogin.Senha = "123";

            var controller = new LoginController(fakeRepository.Object);

            //ação
            var resultado = controller.Login(dadosLogin);


            //verificação
            Assert.IsType<UnauthorizedObjectResult>(resultado);
        }
        [Fact]
        public void LoginController_Token()
        {
            //preparação
            Usuario usuarioRetorno = new Usuario();
            usuarioRetorno.Email = "email@email.com";
            usuarioRetorno.Senha = "1234";
            usuarioRetorno.Tipo = "0";

            var fakeRepository = new Mock<IUsuarioRepository>();
            fakeRepository.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(usuarioRetorno);

            string issuerValidacao = "chapter.webapi";
            LoginViewModels dadosLogin = new LoginViewModels();
            dadosLogin.Email = "batata";
            dadosLogin.Senha = "123";

            var controller = new LoginController(fakeRepository.Object);

            //ação
            OkObjectResult resultado = (OkObjectResult)controller.Login(dadosLogin);

            string token = resultado.Value.ToString().Split()[3];
            var jwtHandler = new JwtSecurityTokenHandler();
            var tokenJwt = jwtHandler.ReadJwtToken(token);

            //verificação
            Assert.Equal(issuerValidacao, tokenJwt.Issuer);



        }

    }
}

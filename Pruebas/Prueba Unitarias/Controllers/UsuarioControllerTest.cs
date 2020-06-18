using Moq;
using NUnit.Framework;
using SimuladorExamenUPN.Controllers;
using SimuladorExamenUPN.Interface;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pruebas.Prueba_Unitarias.Controllers
{
    [TestFixture]
    public class UsuarioControllerTest
    {
       
            [Test]
            public void DebePoderIngresarUsuario() {string Username = "Admin"; string Password = "Admin";
            Usuario usuario = new Usuario(){Id = 1, Nombres = "Anais", Password = "Admin", Username = "Admin"};
               var Login = new Mock<IUsuarioSession>();
                var User = new Mock<IUsuario>();

                User.Setup(p => p.GetUsuario(Username, Password)).Returns(usuario);

                Login.Setup(a => a.AutenticaUsername(Username, true));

                var controller = new UsuarioController(User.Object, Login.Object);


                var rederit = controller.Login(Username, Password);

                Assert.IsInstanceOf<RedirectToRouteResult>(rederit);
                

            }
        }
    
}

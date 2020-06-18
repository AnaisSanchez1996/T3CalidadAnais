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
    public class ExamenControllerTest
    {
        [Test]
        public void DebePoderRetonarUnaListadeExamenes()
        {
            var Examen = new Mock<IExamen>();
            var User = new Mock<IUsuario>();
            Usuario usuario = new Usuario(){Id = 1, Nombres = "Anais", Password = "Admin", Username = "Admin"};
            Examen examens = new Examen() { Id = 1, TemaId = 1, UsuarioId = 1, EstaActivo = true,};
            User.Setup(a => a.setNombreUsuario()).Returns(usuario);
            Examen.Setup(a => a.ExamenesUser(usuario)).Returns(new List<Examen>());
            var controller = new ExamenController(User.Object, Examen.Object, null);
            var view = controller.Index() as ViewResult;
            Assert.IsInstanceOf<ViewResult>(view);

        }
    }
}

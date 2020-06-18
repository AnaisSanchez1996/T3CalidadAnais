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
    public class TemaControllerTest
    {
        [Test]
        public void DebePoderRetonarUnaListadeExamenes()
        {
            var temas = new Mock<ITema>();
            string criterio = "Nombre";

            temas.Setup(a => a.gettemas(criterio)).Returns(new List<Tema>());
            var controller = new TemaController(temas.Object, null);

            var view = controller.Index(criterio) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(view);

        }
        [Test]
        public void DebePoderCrear()
        {
            var Categorias = new Mock<ICategoria>();

            string Criterio = "Nombre";

            Categorias.Setup(a => a.Getcategorias()).Returns(new List<Categoria>());
            var controller = new TemaController(null, Categorias.Object);
            var view = controller.Crear() as ViewResult;
             Assert.IsInstanceOf<ViewResult>(view);

        }
    }
}

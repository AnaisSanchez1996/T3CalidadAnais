using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Pruebas.GlobalLin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas.PruebasSelenium
{
    public class Tema
    {
        ChromeDriver examen = new ChromeDriver();
        [Test]
        public void ClickTema()
        {

            String criterio = "Primera";

            examen.Url = GoblaL.URL;
            examen.FindElementById("usernameId").SendKeys("admin");
            examen.FindElementById("passwordId").SendKeys("admin");
            examen.FindElementById("Login").Click();

            examen.FindElementById("temaLink").Click();
            examen.FindElementById("buscarNombre").SendKeys(criterio);
            examen.FindElementById("buscar").Click();
            Assert.IsTrue(examen.Url.EndsWith("tema/index?criterio=" + criterio));
            examen.Close();
        }
        [Test]
        public void ClickTemaCrear()
        {

            examen.Url = GoblaL.URL;
            examen.FindElementById("usernameId").SendKeys("admin");
            examen.FindElementById("passwordId").SendKeys("admin");
            examen.FindElementById("Login").Click();

            examen.FindElementById("temaLink").Click();

            examen.FindElementById("creartemaLink").Click();

            Assert.IsTrue(examen.Url.EndsWith("/Tema/Crear"));
            examen.Close();
        }
        [Test]
        public void ClickTemaCrearAgregar()
        {

            examen.Url = GoblaL.URL;
            examen.FindElementById("usernameId").SendKeys("admin");
            examen.FindElementById("passwordId").SendKeys("admin");
            examen.FindElementById("Login").Click();

            examen.FindElementById("temaLink").Click();

            examen.FindElementById("creartemaLink").Click();


            examen.FindElementById("Nombre").SendKeys("Anais");
            examen.FindElementById("listacategoria").SendKeys("Historia");
            examen.FindElementById("Descripcion").SendKeys("Historia");

            examen.FindElementById("btnguardartema").Click();

            Assert.IsTrue(examen.Url.EndsWith("/Tema"));
            examen.Close();
        }
    }
}

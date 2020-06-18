using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Pruebas.GlobalLin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas.PruebasSelenium.Login
{
    [TestFixture]
    public class VistaLogin
    {
        ChromeDriver examen = new ChromeDriver();
        [Test]
        public void LogeoIsOk()
        {
            examen.Url = GoblaL.URL;
            examen.FindElementById("usernameId").SendKeys("admin");
            examen.FindElementById("passwordId").SendKeys("admin");
            examen.FindElementById("Login").Click();
            Assert.IsTrue(examen.Url.EndsWith("/"));
            examen.Close();
        }
        [Test]
        public void LogeoIsNoOk()
        {
            examen.Url = GoblaL.URL;
            examen.FindElementById("usernameId").SendKeys("adminsss");
            examen.FindElementById("passwordId").SendKeys("admin");
            examen.FindElementById("Login").Click();
            Assert.IsTrue(examen.Url.EndsWith("/Usuario/Login"));
            examen.Close();
        }
    }

}

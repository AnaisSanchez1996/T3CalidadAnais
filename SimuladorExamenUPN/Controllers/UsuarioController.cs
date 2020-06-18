using SimuladorExamenUPN.Interface;
using SimuladorExamenUPN.Models;
using SimuladorExamenUPN.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SimuladorExamenUPN.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuario iusuarioservi;
        private IUsuarioSession iUsuarioSession;
        public UsuarioController(IUsuario iusuarioservi, IUsuarioSession iUsuarioSession)
        {
            this.iusuarioservi = iusuarioservi;
            this.iUsuarioSession = iUsuarioSession;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {

            var usuarioGet = iusuarioservi.GetUsuario(username, password);

            if (usuarioGet != null)
            {
                iUsuarioSession.AutenticaUsername(username, false);

                iUsuarioSession.SetIdUsuario(usuarioGet);

                return RedirectToAction("Index", "Home");
            }
            ViewBag.Validation = "Usuario y/o contraseña incorrecta";
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
    
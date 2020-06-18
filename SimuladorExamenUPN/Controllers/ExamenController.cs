using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SimuladorExamenUPN.Interface;

namespace SimuladorExamenUPN.Controllers
{
    [Authorize]
    public class ExamenController : Controller
    {


        readonly IUsuario iusuario;
        readonly IExamen iexamene;
        readonly ITema itemas;
        public ExamenController(IUsuario iusuario, IExamen iexamene, ITema itemas)
        {
            this.iusuario = iusuario;
            this.iexamene = iexamene;
            this.itemas = itemas;
        }

        SimuladorContext db;
        public ExamenController()
        {
            db = new SimuladorContext();
        }

        [HttpGet]
        public ActionResult Index()
        {
            Usuario logged = iusuario.setNombreUsuario();
            var examenes = iexamene.ExamenesUser(logged);
            return View(examenes);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            ViewBag.Temas = itemas.temas();
            return View(new Examen());
        }

        [HttpPost]
        public ActionResult Crear(Examen examen, int nroPreguntas)
        {
            if (ModelState.IsValid)
            {
                Usuario user = iusuario.setNombreUsuario();
                return RedirectToAction("Index");
            }

            ViewBag.Temas = itemas.temas();
            return View(examen);
        }
    }
}

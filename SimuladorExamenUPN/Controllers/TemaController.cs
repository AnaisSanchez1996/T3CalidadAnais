using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Interface;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimuladorExamenUPN.Controllers
{
    public class TemaController : Controller
    {
        readonly ITema itemas;
        readonly ICategoria icategoria;

        public TemaController(ITema itemas, ICategoria icategoria)
        {
            this.itemas = itemas;
            this.icategoria = icategoria;
        }

        [HttpGet]
        public ViewResult Index(string criterio)
        {

            var temas = itemas.gettemas(criterio);
            ViewBag.Criterio = criterio;

            return View(temas.ToList());
        }

        [HttpGet]
        public ViewResult Crear()
        {
            ViewBag.Categorias = icategoria.Getcategorias();
            ViewBag.Message = "Pantalla de crear";
            return View(new Tema());
        }

        [HttpPost]
        public ActionResult Crear(Tema tema, List<int> Ids)
        {

            ViewBag.Categorias = icategoria.Getcategorias();

            if (ModelState.IsValid == true)
            {

                itemas.TemasAdd(tema);
                itemas.TemaCategoriasAdd(Ids, tema);
                return RedirectToAction("Index");
            }

            else
            {
                return View(tema);
            }
        }

        [HttpGet]
        public ViewResult Editar(int id)
        {

            Tema tema = itemas.Editar(id);
            return View(tema);
        }

        [HttpPost]
        public ActionResult Editar(Tema tema)
        {
            if (ModelState.IsValid == true)
            {
                itemas.EditatTema(tema);
                return RedirectToAction("Index");
            }

            return View(tema);
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {

            itemas.Eliminar(id);
            return RedirectToAction("Index");
        } 
    }
}
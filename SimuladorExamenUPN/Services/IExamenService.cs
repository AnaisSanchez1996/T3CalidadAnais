using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Interface;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SimuladorExamenUPN.Services
{
    public class IExamenService : IExamen
    {
        private SimuladorContext Context;

        public IExamenService(SimuladorContext Context)
        {
            this.Context = Context;
        }

        public IList<Examen> Getexamenes()
        {
            var examenes = Context.Examenes
                .Include(o => o.Tema.Categorias.Select(s => s.Categoria))
                .Include(o => o.Usuario)
                .Where(o => o.EstaActivo == true)
                .ToList();
            return examenes;
        }

        public Examen Confirmar(int ExamenId)
        {
            var examen = Context.Examenes
               .Where(o => o.Id == ExamenId)
               .Include(o => o.Tema)
               .Include(u => u.Usuario)
               .FirstOrDefault();
            return examen;

        }

        public Examen DarExamen(int ExamenId)
        {
            var examen = Context.Examenes.Where(o => o.Id == ExamenId)
               .Include(o => o.Preguntas.Select(s => s.Pregunta.Alternativas))
               .FirstOrDefault();
            return examen;
        }

        public List<Examen> ExamenesUser(Usuario usuario)
        {
            var examenes = Context.Examenes
                .Where(o => o.UsuarioId == usuario.Id)
                .Include(o => o.Tema)
                .Include(o => o.Preguntas)
                .ToList();
            return examenes;
        }

        public void CrearExamen(Examen examen, int nroPreguntas, Usuario usuario)
        {
            examen.EstaActivo = true;
            GuardarExamen(examen, usuario);
            List<Pregunta> preguntas = GenerarPreguntas(examen.TemaId, nroPreguntas);

            GuardarPreguntas(examen, preguntas);
        }
        private void GuardarPreguntas(Examen examen, List<Pregunta> preguntas)
        {
            foreach (var item in preguntas)
            {
                var examenPreguta = new ExamenPregunta();
                examenPreguta.ExamenId = examen.Id;
                examenPreguta.PreguntaId = item.Id;

                Context.ExamenPreguntas.Add(examenPreguta);

                Context.SaveChanges();
            }
        }
        private void GuardarExamen(Examen examen, Usuario usuario)
        {
            examen.UsuarioId = usuario.Id;
            examen.FechaCreacion = DateTime.Now;
            Context.Examenes.Add(examen);
            Context.SaveChanges();
        }
        private List<Pregunta> GenerarPreguntas(int tema, int nroPreguntas)
        {
            var basePreguntas = Context.Preguntas.Where(o => o.TemaId == tema).ToList();
            return basePreguntas
                .OrderBy(x => Guid.NewGuid())
                .Take(nroPreguntas).ToList();
        }
    }
}
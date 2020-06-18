using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Interface;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace SimuladorExamenUPN.Services
{
    public class ITemaService : ITema
    {
        private SimuladorContext Context;

        public ITemaService(SimuladorContext Context)
        {
            this.Context = Context;
        }
        public IEnumerable<Tema> gettemas(string criterio)
        {
            var temas = Context.Temas.Include(a => a.Categorias.Select(o => o.Categoria)).AsQueryable();

            if (!string.IsNullOrEmpty(criterio))
                temas = temas.Where(o => o.Nombre.Contains(criterio));

            return temas;
        }
        public void TemasAdd(Tema tema)
        {
            Context.Temas.Add(tema);
            Context.SaveChanges();
        }
        public void TemaCategoriasAdd(List<int> Ids, Tema tema)
        {
            foreach (var categoriaid in Ids)
            {
                var temaCategoria = new TemaCategoria() { CategoriaId = categoriaid, TemaId = tema.Id };
                Context.TemaCategorias.Add(temaCategoria);
                Context.SaveChanges();
            }
        }
        public Tema Editar(int id)
        {
            Tema temaA = Context.Temas.Where(x => x.Id == id).First();
            return temaA;
        }

        public void EditatTema(Tema tema)
        {
            Context.Entry(tema).State = EntityState.Modified;
            Context.SaveChanges();
        }
        public void Eliminar(int id)
        {
            Tema tema = Context.Temas.Where(x => x.Id == id).First();
            Context.Temas.Remove(tema);
            Context.SaveChanges();
        }

        public List<Tema> temas()
        {
            var temass = Context.Temas.ToList();
            return temass;
        }
    }
}
using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Interface;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.Services
{
    public class ICategoriaService : ICategoria
    {
        private SimuladorContext Context;

        public ICategoriaService(SimuladorContext Context)
        {
            this.Context = Context;
        }
        public List<Categoria> Getcategorias()
        {
            var cetegorias = Context.Categorias.ToList();
            return cetegorias;
        }
    }
}
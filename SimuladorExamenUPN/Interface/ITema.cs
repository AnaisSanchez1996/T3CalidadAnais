using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorExamenUPN.Interface
{
    public interface ITema
    {
        IEnumerable<Tema> gettemas(string criterio);
        Tema Editar(int id);
        void EditatTema(Tema tema);
        void Eliminar(int id);
        void TemasAdd(Tema tema);
        void TemaCategoriasAdd(List<int> Ids, Tema tema);
        List<Tema> temas();
    }
}

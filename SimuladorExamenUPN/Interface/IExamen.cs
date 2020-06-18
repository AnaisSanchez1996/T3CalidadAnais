using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorExamenUPN.Interface
{
    public interface IExamen
    {
        IList<Examen> Getexamenes();
        Examen Confirmar(int ExamenId);
        Examen DarExamen(int ExamenId);
        List<Examen> ExamenesUser(Usuario usuario);
        void CrearExamen(Examen examen, int nroPreguntas, Usuario usuario);
    }
}

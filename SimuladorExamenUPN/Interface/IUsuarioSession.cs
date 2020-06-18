using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorExamenUPN.Interface
{
    public interface IUsuarioSession
    {
        void SetIdUsuario(Usuario usuario);
        void AutenticaUsername(String Username, bool valor);
    }
}

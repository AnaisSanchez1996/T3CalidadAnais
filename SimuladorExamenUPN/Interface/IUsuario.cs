using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorExamenUPN.Interface
{
    public interface IUsuario
    {
        Usuario GetUsuario(string username, string password);
        Usuario setNombreUsuario();
    }
}

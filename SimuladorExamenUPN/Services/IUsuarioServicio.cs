using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Interface;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace SimuladorExamenUPN.Services
{
    public class IUsuarioServicio : IUsuario
    {
        private SimuladorContext Context;
        HttpSessionState session = HttpContext.Current.Session;
        public IUsuarioServicio(SimuladorContext Context)
        {
            this.Context = Context;
        }
        public Usuario GetUsuario(string username, string password)
        {
            var usuario = Context.Usuarios.Where(a => a.Username == username && a.Password == password).FirstOrDefault();
            return usuario;
        }

        public Usuario setNombreUsuario()
        {
            return (Usuario)session["Usuario"];
        }
    }
}
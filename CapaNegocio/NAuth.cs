using CapaDatos;
using DAO;
using DAOImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
  public class NAuth
    {
        //LOGIN
        public async Task<HttpResponseMessage> LoginUsuario(string dataLogin)
        {
            IAuthDao authDao = new AuthDaoImpl();

            HttpResponseMessage usuarioResponse = await authDao.LoginUsuario(dataLogin);

            return usuarioResponse;
        }
        //FIN LOGIN..................................
    }
}

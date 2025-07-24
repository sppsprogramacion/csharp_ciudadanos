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
        public async Task<(bool, string)> LoginUsuario(string dataLogin)
        {
            IAuthDao authDao = new AuthDaoImpl();

            (bool acceso, string errorResponse) = await authDao.LoginUsuario(dataLogin);

            return (acceso, errorResponse); 
        }
        //FIN LOGIN..................................
    }
}

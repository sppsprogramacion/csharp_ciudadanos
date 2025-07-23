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
    public class NRegistroDiario
    {
        //CARGAR DATOS DE REGISTRO DIARIO
        public async Task<(DRegistroDiario, string error)> crearRegistroDiario(string registroDiario)
        {
            IRegistroDiarioDao registroDiarioDao = new RegistroDiarioDaoImpl();

            (DRegistroDiario prohibicionResponse, string errorResponse) = await registroDiarioDao.crearRegistroDiario(registroDiario);

            return (prohibicionResponse, errorResponse);
        }
        //FIN CARGAR DATOS DE CREGISTRO DIARIO..................................
    }
}

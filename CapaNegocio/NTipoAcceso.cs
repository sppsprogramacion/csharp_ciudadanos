using CapaDatos;
using DAO;
using DAOImplement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NTipoAcceso
    {
        //RETORNAR TIPO DE ACCESO TODOS
        public async Task<(List<DTipoAcceso>, string error)> RetornarTipoAcceso()
        {
            ITipoAcceso tipoAccesoDao = new TipoAccesoDaoImpl();

            (List<DTipoAcceso> listaTipoAcceso, string errorResponse) = await tipoAccesoDao.retornarTipoAcceso();


            return (listaTipoAcceso, errorResponse);
        }
        //FIN RETORNAR TIPO DE ACCESO TODOS..................................
    }
}

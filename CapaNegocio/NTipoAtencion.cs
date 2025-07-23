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
    public class NTipoAtencion
    {
        //RETORNAR TIPO DE ATENCION TODOS
        public async Task<(List<DTipoAtencion>, string error)> RetornarTipoAtencion()
        {
            ITipoAtencion tipoAtencionDao = new TipoAtencionDaoImpl();

            (List<DTipoAtencion> listaTipoAtencion, string errorResponse) = await tipoAtencionDao.retornarTipoAtencion();


            return (listaTipoAtencion, errorResponse);
        }
        //FIN RETORNAR TIPO DE ATENCION TODOS..................................
    }
}

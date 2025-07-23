using CapaDatos;
using DAO;
using DAOImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NMotivoAtencion
    {
        //RETORNAR MOTIVO ATENCION TODOS
        public async Task<(List<DMotivoAtencion>, string error)> RetornarMotivoAtencionXOrganismo(int id_organismo)
        {
            IMotivoAtencionDao motivoAtencionDao = new MotivoAtencionDaoImpl();

            (List<DMotivoAtencion> listaMotivoAtencion, string errorResponse) = await motivoAtencionDao.retornarMotivoAtencionXOrganismo(id_organismo);


            return (listaMotivoAtencion, errorResponse);
        }
        //FIN RETORNAR MOTIVO ATENCION TODOS..................................

    }
}

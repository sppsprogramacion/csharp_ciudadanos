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
    public class NSectoresDestino
    {
        //RETORNAR SECTORES DESTINO POR ORGANISMO
        public async Task<(List<DSectoresDestino>, string error)> RetornarListaSectoresXOrganismo(int id_organismo_destino)
        {
            ISectoresDestino sectoresDestinoDao = new SectoresDestinoDaoImpl();

            (List<DSectoresDestino> listaSectoresDestino, string errorResponse) = await sectoresDestinoDao.RetornarListaSectoresXOrganismo(id_organismo_destino);


            return (listaSectoresDestino, errorResponse);
        }
        //FIN RETORNAR SECTERES POR ORGANISMO..................................


    }
}

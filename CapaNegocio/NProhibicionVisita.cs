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
    public class NProhibicionVisita
    {
               

        //RETORNAR PROHIBICIONES VISITA POR CIUDADANO
        public async Task<(List<DProhibicionVisita>, string error)> RetornarListaProhibicionesVisita(int idCiudadano)
        {
            IProhibicionVisitaDao prohibicionVisitaDao = new ProhibicinVisitaDaoImpl();

            (List<DProhibicionVisita> listaProhibicionesVisita, string errorResponse) = await prohibicionVisitaDao.RetornarProhibicionesVisitaXCiudadano(idCiudadano);


            return (listaProhibicionesVisita, errorResponse);
        }
        //FIN RETORNAR PROHIBICIONES VISITA POR CIUDADANO..................................
    }
}

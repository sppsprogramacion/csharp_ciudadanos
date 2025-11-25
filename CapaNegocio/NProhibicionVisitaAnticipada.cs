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
    public class NProhibicionVisitaAnticipada
    {
        
        //BUSCAR X ID
        public async Task<(DProhibicionAnticipada, string error)> BuscarProhibicionXId(int id)
        {
            IProhibicionVisitaAnticipadaDao prohibicionDao = new ProhibisionVisitaAnticipadaDaoImpl();

            (DProhibicionAnticipada dProhibicion, string error) = await prohibicionDao.BuscarProhibicionAnticipadaXId(id);


            return (dProhibicion, error);
        }
        //FIN BUSCAR XID..................................

                
        //RETORNAR X APELLIDO
        public async Task<(List<DProhibicionAnticipada>, string error)> ListaProhibicionesXApellido(string apellido)
        {
            IProhibicionVisitaAnticipadaDao prohibicionAnticipadaDao = new ProhibisionVisitaAnticipadaDaoImpl();

            (List<DProhibicionAnticipada> listaProhibiciones, string error) = await prohibicionAnticipadaDao.ListaProhibicionesAnticipadasXApellido(apellido);

            return (listaProhibiciones, error);
        }
        //FIN RETORNAR X APELLIDO..................................
    }
}

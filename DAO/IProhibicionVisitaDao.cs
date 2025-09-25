using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IProhibicionVisitaDao
    {
        Task<(DProhibicionVisita, string error)> BuscarProhibicionVisitaXId(int idProhibicionvisita);

        Task<(List<DProhibicionVisita>, string error)> RetornarProhibicionesVisitaXCiudadano(int idCiudadano);


    }
}

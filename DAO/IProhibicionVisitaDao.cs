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
        Task<(DProhibicionVisita, string error)> CrearProhivisionVisita(string prohibicionVisita);

        Task<(bool, string error)> EditarProhibicionVisita(int id, string prohibicionVisita);

        Task<(bool, string error)> LevantarProhibicionVisita(int id, string dataLevantar);

        Task<(bool, string error)> ProhibirProhibicionVisita(int id, string dataProhibir);

        Task<(bool, string error)> AnularProhibicionVisita(int id, string dataAnular);

        Task<(DProhibicionVisita, string error)> BuscarProhibicionVisitaXId(int idProhibicionvisita);

        Task<(List<DProhibicionVisita>, string error)> RetornarProhibicionesVisitaXCiudadano(int idCiudadano);


    }
}

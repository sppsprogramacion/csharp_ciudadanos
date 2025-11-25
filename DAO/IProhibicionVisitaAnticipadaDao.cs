using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IProhibicionVisitaAnticipadaDao
    {
       Task<(DProhibicionAnticipada, string error)> BuscarProhibicionAnticipadaXId(int idProhibicionvisita);
        Task<(List<DProhibicionAnticipada>, string error)> ListaProhibicionesAnticipadasXApellido(string apellido);
       
    }
}

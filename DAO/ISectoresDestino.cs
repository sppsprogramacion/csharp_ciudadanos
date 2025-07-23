using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface ISectoresDestino
    {
        Task<(List<DSectoresDestino>, string error)> RetornarListaSectoresXOrganismo(int id_organismo_destino);
    }
}

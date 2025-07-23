using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IMotivoAtencionDao
    {
        Task<(List<DMotivoAtencion>, string error)> retornarMotivoAtencionXOrganismo(int id_organismo_destino);
    }
}

using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IEstadoCivilDao
    {
        DEstadoCivil buscarEstadoCivilXId(int id);

        Task<(List<DEstadoCivil>, string error)> retornarListaEstadoCivil();
    }
}

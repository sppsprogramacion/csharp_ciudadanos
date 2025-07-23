using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface ISexoDao
    {
        int crearSexo(DCiudadano usuario);

        int editarSexo(DCiudadano usuario);

        DSexo buscarSexoXId(int id);
        Task<(List<DSexo>, string error)> retornarListaSexo();

    }
}

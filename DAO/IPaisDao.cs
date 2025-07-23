using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IPaisDao
    {
        int crearPais(DPais usuario);

        int editarPais(DPais usuario);

        DPais buscarPaisXId(int id);

        Task<(List<DPais>, string error)> retornarListaPais();
    }
}

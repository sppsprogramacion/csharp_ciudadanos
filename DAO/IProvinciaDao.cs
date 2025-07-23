using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IProvinciaDao
    {//inicio clase
        int crearProvincia(DProvincia usuario);

        int editarProvincia(DProvincia usuario);

        DProvincia buscarProvinciaXId(int id);

        Task<(List<DProvincia>, string error)> retornarListaProvinciasXPais(string id_pais);
    }//fin de clase
}

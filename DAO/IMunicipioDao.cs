using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IMunicipioDao
    {//inicio clase
        int crearMunicipio(DMunicipio usuario);

        int editarMunicipio(DMunicipio usuario);

        DMunicipio buscarMunicipioXId(int id);

        Task<(List<DMunicipio>, string error)> retornarListaMunicipioXDepartamento(int departamento_id);
    }//fin clase
}

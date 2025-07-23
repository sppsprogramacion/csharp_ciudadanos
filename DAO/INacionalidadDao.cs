using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public interface INacionalidadDao
    {
        int crearNacionalidad(DCiudadano usuario);

        int editarNacionalidad(DCiudadano usuario);

        DNacionalidad buscarNacionalidadXId(int id);

        Task<(List<DNacionalidad>, string error)> retornarListaNacionalidad();
    }
}

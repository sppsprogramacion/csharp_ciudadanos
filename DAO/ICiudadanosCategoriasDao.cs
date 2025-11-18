using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface ICiudadanosCategoriasDao
    {
        Task<(DCiudadanosCategorias, string error)> crearCiudadanosCategorias(string ciudadanosCategorias);
        Task<(List<DCiudadanosCategorias>, string error)> retornarListaCategoriasVigentesXCiudadano(int dni);
        Task<(List<DCiudadanosCategorias>, string error)> retornarListaCategoriasHistoricasXCiudadano(int id_ciudadano);
        Task<(bool, string error)> QuitarCategoria(int id, string dataQuitar);

    }
}

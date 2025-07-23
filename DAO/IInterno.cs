using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;


namespace DAO
{
    public interface IInternoDaoo
    {//inicio clase
        //Task<List<DCiudadano>> retornarListaInternoXApellido(string apellido);
        Task<(List<DInterno>, string error)> retornarListaInternoXApellido(string apellido);
    }//fin clase
}

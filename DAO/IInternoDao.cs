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
    public interface IInternoDao
    {//inicio clase
        //Task<List<DInterno>> retornarListaInternoXApellido(string apellido);
        Task<(List<DInterno>, string error)> retornarListaInternoXApellido(string apellido);
    }//fin clase
}

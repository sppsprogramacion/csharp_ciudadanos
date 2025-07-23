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
    public interface IAbogadoInternoDao
    {
        Task<(DAbogadoInterno, string error)> asignarAbogadoInterno(string abogadoInterno);
        Task<(DAbogadoInterno, string error)> crearRegistroAbogado(string abogadoInterno);
        Task<(List<DAbogadoInterno>, string error)> retornarListaInternosXId(int idAbogado);
    }
}

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
    public interface IVisitaInternoDao
    {
        Task<(DVisitaInterno, string error)> crearVisitaInterno(string visitainterno);
        Task<(List<DVisitaInterno>, string error)> retornarListaVisitaInternoXCiudadano(int dni);
       
    }
}

using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IExcepcionIngresoVisitaDao
    {
        Task<(DExcepcionIngresoVisita, string error)> BuscarExcepcionIngresoVisitaXId(int idExcepcionIngresoVisita);
        Task<(List<DExcepcionIngresoVisita>, string error)> RetornarExcepcionesIngresoXCiudadano(int idCiudadano);
        Task<(List<DExcepcionIngresoVisita>, string error)> ListaExcepcionesIngresoXFecha(string fechaExcepcionInicio, string fechaExcepcionFin);
        Task<(bool, string error)> CumplimentarExcepcion(int id, string dataCumplimentar);
    }
}

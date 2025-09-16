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
        Task<(DExcepcionIngresoVisita, string error)> CrearExcepcionIngresoVisita(string excepcionIngresoVisita);
        Task<(DExcepcionIngresoVisita, string error)> BuscarExcepcionIngresoVisitaXId(int idExcepcionIngresoVisita);
        Task<(List<DExcepcionIngresoVisita>, string error)> RetornarExcepcionesIngresoXCiudadano(int idCiudadano);
        Task<(List<DExcepcionIngresoVisita>, string error)> ListaExcepcionesIngresoXFecha(string fechaExcepcion);
        Task<(bool, string error)> AnularExcepcion(int id, string dataAnular);
        Task<(bool, string error)> CumplimentarExcepcion(int id, string dataCumplimentar);
    }
}

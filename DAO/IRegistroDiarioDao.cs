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
    public interface IRegistroDiarioDao
    {
        Task<(DRegistroDiario, string error)> crearRegistroDiario(string registroDiario);

        Task<(List<DRegistroDiario>, string error)> ListaXCiudadano(int idCiudadano);
        Task<(List<DRegistroDiario>, string error)> retornarListaRegistroDiario(string fecha_ingreso, string hora_inicio, string hora_fin);
        Task<(List<DRegistroDiario>, string error)> retornarListaPendienteSalida();
        Task<(HttpResponseMessage, string error)> crearEgresoRegistroDiario(int id_ciudadano, string hora_egreso);


    }
}

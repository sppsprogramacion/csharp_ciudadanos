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
    public interface ICiudadanoDao
    {
        Task<(DCiudadano, string error )> crearCiudadano(string ciudadano);

        int editarCiudadano(DCiudadano ciudadano);

        DCiudadano buscarCiudadanoXDni(int dni);

        //DCiudadano buscarCiudadanoXId(int id);
        Task<(DCiudadano, string error)> buscarCiudadanoXId(int id);

        Task<(List<DCiudadano>, string error)> retornarListaCiudadano();

        Task<(List<DCiudadano>, string error)> retornarListaCiudadanoXDni(int dni);
        
        Task<(List<DCiudadano>, string error)> retornarListaCiudadanoXApellido(string apellido);
    
        Task<HttpResponseMessage> editarCiudadanoDni(int dni, string ciudadano);
        Task<HttpResponseMessage> editarDatosPersonales(int id, string ciudadano);
        Task<(bool, string error)> establecerVisita(int id, string novedad_detalle);
        Task<(bool, string error)> establecerDiscapacidad(int id, string novedad_detalle);


        //DataTable retornarCiudadanosTodos();
    }
}

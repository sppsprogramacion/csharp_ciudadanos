using CapaDatos;
using DAO;
using DAOImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NCiudadano
    {
        //RETORNAR CIUDADANOS TODOS
        public async Task<(List<DCiudadano>, string errorResponse)> RetornarListaCiudadanos()
        {
            ICiudadanoDao ciudadanoDao = new CiudadanoDaoImpl();
            //Realizar este metodo mañana para completar los metodos de programa ciudadanos
            (List<DCiudadano> listaCiudadanos, string errorResponse) = await ciudadanoDao.retornarListaCiudadano();
            

            return (listaCiudadanos, errorResponse);
        }
        //FIN RETORNAR CIUDADNAOS TODOS..................................

        //RETORNAR CIUDADANOS X APELLIDO
        public async Task<(List<DCiudadano>, string error)> RetornarListaCiudadanosXapellido(string apellido)
        {
            ICiudadanoDao ciudadanoDao = new CiudadanoDaoImpl();

            (List<DCiudadano> listaCiudadanos, string errorResponse) = await ciudadanoDao.retornarListaCiudadanoXApellido(apellido);


            return (listaCiudadanos, errorResponse);
        }
        //FIN RETORNAR CIUDADANOS POR APELLIDO..................................

        //RETORNAR CIUDADANOS X DNI
        public async Task<(List<DCiudadano>, string error)> RetornarListaCiudadanosXdni(int dni)
        {
            ICiudadanoDao ciudadanoDao = new CiudadanoDaoImpl();

            (List<DCiudadano> listaCiudadanos, string errorResponse) = await ciudadanoDao.retornarListaCiudadanoXDni(dni);


            return (listaCiudadanos, errorResponse);


        }
        //FIN RETORNAR CIUDADANOS POR DNI..................................



        //RETORNAR CIUDADANO X ID
        public async Task<(DCiudadano, string error)> BuscarCiudadanoXID(int id)
        {
            ICiudadanoDao ciudadanoDao = new CiudadanoDaoImpl();

            (DCiudadano ciudadano, string errorResponse) = await ciudadanoDao.buscarCiudadanoXId(id);


            return (ciudadano, errorResponse);
        }




        //CARGAR DATOS DE CIUDADANOS
        public async Task<(DCiudadano, string error)> crearCiudadano(string ciudadano)
        {
            ICiudadanoDao ciudadanoDao = new CiudadanoDaoImpl();

            (DCiudadano prohibicionResponse, string errorResponse) = await ciudadanoDao.crearCiudadano(ciudadano);

            return (prohibicionResponse, errorResponse);
        }
        //FIN CARGAR DATOS DE CIUDADANOS..................................



       



        //EDITAR DATOS DE DOMICILIO DE CIUDADANOS
        public async Task<HttpResponseMessage> editarCiudadanoDni(int id, string ciudadano)
        {
            ICiudadanoDao ciudadanoDao = new CiudadanoDaoImpl();

            HttpResponseMessage ciudadanoResponse = await ciudadanoDao.editarCiudadanoDni(id, ciudadano);

            return ciudadanoResponse;
        }
        //FIN editar DATOS DE DOMICILIO CIUDADANOS..................................

        //EDITAR DATOS PERSONALES DE CIUDADANOS
        public async Task<HttpResponseMessage> editarDatosPersonales(int id, string ciudadano)
        {
            ICiudadanoDao ciudadanoDao = new CiudadanoDaoImpl();

            HttpResponseMessage ciudadanoResponse = await ciudadanoDao.editarDatosPersonales(id, ciudadano);

            return ciudadanoResponse;
        }
        //FIN editar DATOS PERSONALES CIUDADANOS..................................

        //ASIGNAR CIUDADANOS COMO VICITAS
        public async Task<HttpResponseMessage> establecerVisita(int id, string ciudadano)
        {
            ICiudadanoDao ciudadanoDao = new CiudadanoDaoImpl();

            HttpResponseMessage ciudadanoResponse = await ciudadanoDao.establecerVisita(id, ciudadano);

            return ciudadanoResponse;
        }
        //FIN editar ASOGNAR CIUDADANOS COMO VISITAS..................................


    }
}

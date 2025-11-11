using CapaDatos;
using DAO;
using DAOImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NRegistroDiario
    {
        //CARGAR DATOS DE REGISTRO DIARIO
        public async Task<(DRegistroDiario, string error)> crearRegistroDiario(string registroDiario)
        {
            IRegistroDiarioDao registroDiarioDao = new RegistroDiarioDaoImpl();

            (DRegistroDiario prohibicionResponse, string errorResponse) = await registroDiarioDao.crearRegistroDiario(registroDiario);

            return (prohibicionResponse, errorResponse);
        }
        //FIN CARGAR DATOS DE CREGISTRO DIARIO..................................

        //RETORNAR LISTA POR CIUDADANO
        public async Task<(List<DRegistroDiario>, string error)> RetornarListaXCiudadano(int idCiudadano)
        {
            IRegistroDiarioDao registroDiarioDao = new RegistroDiarioDaoImpl();

            (List<DRegistroDiario> listaRegsitroDiario, string errorResponse) = await registroDiarioDao.ListaXCiudadano(idCiudadano);


            return (listaRegsitroDiario, errorResponse);
        }
        //FIN RETORNAR LISTA POR CIUDADANO

        //RETORNAR LISTA REGISTRO DIARIO POR FECHA
        public async Task<(List<DRegistroDiario>, string error)> retornarListaRegistroDiario(string fecha_ingreso, string hora_inicio, string hora_fin)
        {
            IRegistroDiarioDao registroDiarioDao = new RegistroDiarioDaoImpl();

            (List<DRegistroDiario> listaRegsitroDiario, string errorResponse) = await registroDiarioDao.retornarListaRegistroDiario(fecha_ingreso, hora_inicio, hora_fin);


            return (listaRegsitroDiario, errorResponse);
        }
        //FIN RETORNAR LISTA REGISTRO DIARIO POR FECHA..................................

        //RETORNAR LISTA PENDIENTE DE SALIDA
        public async Task<(List<DRegistroDiario>, string error)> retornarListaPendienteSalida()
        {
            IRegistroDiarioDao registroDiarioDao = new RegistroDiarioDaoImpl();

            (List<DRegistroDiario> listaRegsitroDiario, string errorResponse) = await registroDiarioDao.retornarListaPendienteSalida();


            return (listaRegsitroDiario, errorResponse);
        }
        //FIN RETORNAR LISTA PENDIENTE DE SALIDA..................................

        //DAR SALIDA A CIDADANOS 
       public async Task<HttpResponseMessage> crearEgresoRegistroDiario(int idRegistroDiario, string dataRegistroDiario)

        {
            IRegistroDiarioDao registroDiarioDao = new RegistroDiarioDaoImpl();

            HttpResponseMessage registroDiarioResponse = await registroDiarioDao.crearEgresoRegistroDiario(idRegistroDiario, dataRegistroDiario);

            return registroDiarioResponse;

        }
        //FIN DAR SALIDA A CIUDADANOS



    }
}

using CapaDatos;
using DAO;
using DAOImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NExcepcionIngresoVisita
    {
        //CREAR EXCEPCION
        public async Task<(DExcepcionIngresoVisita, string error)> CrearExcepcion(string excepcionIngreso)
        {
            IExcepcionIngresoVisitaDao excepcionIngresoVisitaDao = new ExcepcionIngresoVisitaDaoImpl();

            (DExcepcionIngresoVisita excepcionIngresoResponse, string errorResponse) = await excepcionIngresoVisitaDao.CrearExcepcionIngresoVisita(excepcionIngreso);

            return (excepcionIngresoResponse, errorResponse);
        }
        //FIN CREAR EXCEPCION..................................
                        

        //CUMPLIMENTAR UNA EXCEPCION
        public async Task<(bool, string error)> CumplimentarExcepcion(int id, string dataCumplimentar)
        {
            IExcepcionIngresoVisitaDao excepcionIngresoVisitaDao = new ExcepcionIngresoVisitaDaoImpl();

            (bool excepcionIngresoResponse, string error) = await excepcionIngresoVisitaDao.CumplimentarExcepcion(id, dataCumplimentar);

            return (excepcionIngresoResponse, error);
        }
        //FIN CUMPLIMENTAR UNA EXCEPCION..................................

        //ANULAR UNA EXCEPCION
        public async Task<(bool, string error)> AnularExcepcion(int id, string dataAnular)
        {
            IExcepcionIngresoVisitaDao excepcionIngresoVisitaDao = new ExcepcionIngresoVisitaDaoImpl();

            (bool excepcionIngresoResponse, string error) = await excepcionIngresoVisitaDao.AnularExcepcion(id, dataAnular);

            return (excepcionIngresoResponse, error);
        }
        //FIN ANULAR UNA EXCEPCION..................................


        //LISTA EXCEPCIONES INGRESO POR CIUDADANO
        public async Task<(List<DExcepcionIngresoVisita>, string error)> ListaExcepcionesIngreso(int idCiudadano)
        {
            IExcepcionIngresoVisitaDao excepcionIngresoVisitaDao = new ExcepcionIngresoVisitaDaoImpl();

            (List<DExcepcionIngresoVisita> listaExcepcionesIngreso, string errorResponse) = await excepcionIngresoVisitaDao.RetornarExcepcionesIngresoXCiudadano(idCiudadano);


            return (listaExcepcionesIngreso, errorResponse);
        }
        //FIN LISTA EXCEPCIONES INGRESO POR CIUDADANO..................................

        //LISTA EXCEPCIONES INGRESO POR fecha
        public async Task<(List<DExcepcionIngresoVisita>, string error)> ListaExcepcionesIngresoXFecha(string fechaExcepcion)
        {
            IExcepcionIngresoVisitaDao excepcionIngresoVisitaDao = new ExcepcionIngresoVisitaDaoImpl();

            (List<DExcepcionIngresoVisita> listaExcepcionesIngreso, string errorResponse) = await excepcionIngresoVisitaDao.ListaExcepcionesIngresoXFecha(fechaExcepcion);


            return (listaExcepcionesIngreso, errorResponse);
        }
        //FIN LISTA EXCEPCIONES INGRESO POR FECHA..................................
    }
}

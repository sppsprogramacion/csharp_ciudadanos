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
    public class NProhibicionVisita
    {
        //CREAR PROHIBICION
        public async Task<(DProhibicionVisita, string error)> CrearProhibicion(string prohibicioVisita)
        {
            IProhibicionVisitaDao prohibicionVisitaDao = new ProhibicinVisitaDaoImpl();

            (DProhibicionVisita prohibicionResponse, string errorResponse) = await prohibicionVisitaDao.CrearProhivisionVisita(prohibicioVisita);

            return (prohibicionResponse, errorResponse);
        }
        //FIN CREAR PROHIBICION..................................

        //EDITAR PROHIBICION
        public async Task<(bool, string error)> EditarProhibicion(int id,string prohibicioVisita)
        {
            IProhibicionVisitaDao prohibicionVisitaDao = new ProhibicinVisitaDaoImpl();

            (bool prohibicionResponse, string error) = await prohibicionVisitaDao.EditarProhibicionVisita(id,prohibicioVisita);

            return (prohibicionResponse, error);
        }
        //FIN EDITAR PROHIBICION..................................

        //LEVANTAR MANUAL PROHIBICION
        public async Task<(bool, string error)> LevantarManualProhibicion(int id, string dataLevantar)
        {
            IProhibicionVisitaDao prohibicionVisitaDao = new ProhibicinVisitaDaoImpl();

            (bool prohibicionResponse, string error) = await prohibicionVisitaDao.LevantarProhibicionVisita(id, dataLevantar);

            return (prohibicionResponse, error);
        }
        //FIN LEVANTAR MANUAL PROHIBICION..................................

        //PROHIBIR UNA PROHIBICION
        public async Task<(bool, string error)> ProhibirManualProhibicion(int id, string dataProhibir)
        {
            IProhibicionVisitaDao prohibicionVisitaDao = new ProhibicinVisitaDaoImpl();

            (bool prohibicionResponse, string error)  = await prohibicionVisitaDao.ProhibirProhibicionVisita(id, dataProhibir);

            return (prohibicionResponse, error);
        }
        //FIN PROHIBIR UNA PROHIBICION..................................

        //ANULAR UNA PROHIBICION
        public async Task<(bool, string error)> AnularProhibicion(int id, string dataAnular)
        {
            IProhibicionVisitaDao prohibicionVisitaDao = new ProhibicinVisitaDaoImpl();

            (bool prohibicionResponse, string error) = await prohibicionVisitaDao.AnularProhibicionVisita(id, dataAnular);

            return (prohibicionResponse, error);
        }
        //FIN ANULAR UNA PROHIBICION..................................


        //RETORNAR PROHIBICIONES VISITA POR CIUDADANO
        public async Task<(List<DProhibicionVisita>, string error)> RetornarListaProhibicionesVisita(int idCiudadano)
        {
            IProhibicionVisitaDao prohibicionVisitaDao = new ProhibicinVisitaDaoImpl();

            (List<DProhibicionVisita> listaProhibicionesVisita, string errorResponse) = await prohibicionVisitaDao.RetornarProhibicionesVisitaXCiudadano(idCiudadano);


            return (listaProhibicionesVisita, errorResponse);
        }
        //FIN RETORNAR PROHIBICIONES VISITA POR CIUDADANO..................................
    }
}

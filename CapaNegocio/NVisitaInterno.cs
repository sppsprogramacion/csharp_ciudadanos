using CapaDatos;
using DAO;
using DAOImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NVisitaInterno
    {
        //CARGAR DATOS DE VINCULOS VISITA INTERNO
        public async Task<(DVisitaInterno, string error)> crearVisitaInterno(string visitainterno)
        {
            //ICiudadanoDao ciudadanoDao = new CiudadanoDaoImpl();
            IVisitaInternoDao visitainternoDao = new VisitaInternoDaoImpl();


            (DVisitaInterno visitasInternosResponse, string errorResponse) = await visitainternoDao.crearVisitaInterno(visitainterno);

            return (visitasInternosResponse, errorResponse);
        }
        //FIN CARGAR DATOS DE VINCULOS VISITA INTERNO..................................



        //RETORNAR VINCULOS VISITA INTERNO
        public async Task<(List<DVisitaInterno>, string errprResponse)> retornarListaVisitaInternoXCiudadano(int id_ciudadano)
        {
            IVisitaInternoDao visitainternoDao = new VisitaInternoDaoImpl();

            (List<DVisitaInterno> listaVisitaInterno, string errorResponse) = await visitainternoDao.retornarListaVisitaInternoXCiudadano(id_ciudadano);
                //List<DCiudadano> listaCiudadanos = await ciudadanoDao.retornarListaCiudadanoXDni(dni);



            return (listaVisitaInterno, errorResponse);


        }
        //FIN CARGAR VINCULOS VISITA INTERNO..................................
    }
}

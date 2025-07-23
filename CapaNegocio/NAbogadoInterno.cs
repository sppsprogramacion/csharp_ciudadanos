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
    public class NAbogadoInterno
    {
        //CREAR ASIGNACION ABOGADO INTERNO
        public async Task<(DAbogadoInterno, string error)> asignarAbogadoInterno(string abogadoInterno)
        {
            IAbogadoInternoDao abogadoInternoDao = new AbogadoInternoDaoImpl();

            (DAbogadoInterno prohibicionResponse, string errorResponse) = await abogadoInternoDao.asignarAbogadoInterno(abogadoInterno);

            return (prohibicionResponse, errorResponse);


        }
        //FIN CREAR ASIGNACION..................................

        //CREAR REGISTRO ABOGADO INTERNO
        public async Task<(DAbogadoInterno, string error)> crearCiudadanosCategorias(string abogadoInterno)
        {
            IAbogadoInternoDao abogadoInternoDao = new AbogadoInternoDaoImpl();

            (DAbogadoInterno prohibicionResponse, string errorResponse) = await abogadoInternoDao.crearRegistroAbogado(abogadoInterno);

            return (prohibicionResponse, errorResponse);


        }
        //FIN CREAR REGISTRO ABOGADO INTERNO..................................

        //RETORNAR INTERNOS ASIGNADOS A UN ABOGADO X ID
        public async Task<(List<DAbogadoInterno>, string error)> retornarListaInternosXId(int idAbogado)
        {
            IAbogadoInternoDao abogadoInternoDao = new AbogadoInternoDaoImpl();

            (List<DAbogadoInterno> listaAbogadoInternos, string errorResponse) = await abogadoInternoDao.retornarListaInternosXId(idAbogado);


            return (listaAbogadoInternos, errorResponse);
        }
        //FIN RETORNAR INTERNOS ASIGNADOS A UN ABOGADO X ID..................................
    }
}

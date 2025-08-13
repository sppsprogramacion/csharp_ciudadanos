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
    public class NMenorACargo
    {
        //CREAR DATOS DE VINCULOS ADULTO CON MENOR
        public async Task<(DMenorACargo, string error)> crearMenorACargo(string adultoMenor)
        {
            IMenorACargo menorACargoDao = new MenorACargoDaoImplement();

            (DMenorACargo menorACargoRespone, string errorResponse) = await menorACargoDao.CrearMenorACargo(adultoMenor);

            return (menorACargoRespone, errorResponse);
        }
        //FIN CREAR DATOS DE VINCULOS ADULTO CON MENOR..................................



        //RETORNAR VINCULOS ADULTO CON MENOR
        public async Task<(List<DMenorACargo>, string errprResponse)> retornarListaVigentesXAdulto(int id_ciudadano)
        {
            IMenorACargo menorACargoDao = new MenorACargoDaoImplement();

            (List<DMenorACargo> listaResponse, string errorResponse) = await menorACargoDao.RetornarListaVigentesXAdulto(id_ciudadano);
            //List<DCiudadano> listaCiudadanos = await ciudadanoDao.retornarListaCiudadanoXDni(dni);



            return (listaResponse, errorResponse);


        }
        //FIN VINCULOS ADULTO CON MENOR..................................
    }
}

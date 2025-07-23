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
    public class NCiuddanosCategorias
    {

        
        //CREAR CATEGORIAS
        public async Task<(DCiudadanosCategorias, string error)> crearCiudadanosCategorias(string ciudadanosCategorias)
        {
            ICiudadanosCategoriasDao ciudadanosCategoriasDao = new CiudadanosCategoriasDaoImpl();

            (DCiudadanosCategorias prohibicionResponse, string errorResponse) = await ciudadanosCategoriasDao.crearCiudadanosCategorias(ciudadanosCategorias);

            return (prohibicionResponse, errorResponse);


        }
        //FIN CREAR CATEGORIAS..................................



    }
}

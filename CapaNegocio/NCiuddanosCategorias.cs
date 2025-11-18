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


        //RETORNAR LISTA CATEGORIAS VIGENTES DEL CIUDADANO XID
        public async Task<(List<DCiudadanosCategorias>, string errprResponse)> retornarCiudadanosCategoriasVigentesXCiudadano(int id_ciudadano)
        {
            ICiudadanosCategoriasDao ciudadanosCategoriasDao = new CiudadanosCategoriasDaoImpl();

            (List<DCiudadanosCategorias> listaCiudadanosCategorias, string errorResponse) = await ciudadanosCategoriasDao.retornarListaCategoriasVigentesXCiudadano(id_ciudadano);
           

            return (listaCiudadanosCategorias, errorResponse);

        }
        //FIN RETORNAR LISTA CATEGORIAS VIGENTES DEL CIUDADANO XID..................................


        //QUITAR CATEGORIA
        public async Task<(bool, string error)> QuitarCategoria(int id, string dataQutar)
        {
            ICiudadanosCategoriasDao ciudadanosCategoriasDao = new CiudadanosCategoriasDaoImpl();

            (bool ciudadanoCategoriaResponse, string error) = await ciudadanosCategoriasDao.QuitarCategoria(id, dataQutar);

            return (ciudadanoCategoriaResponse, error);
        }
        //FIN QUITAR CATEGORIA..................................

        //RETORNAR LISTA CATEGORIAS DEL CIUDADANO XID
        public async Task<(List<DCiudadanosCategorias>, string errprResponse)> retornarCiudadanosCategoriasHistoricasXCiudadano(int id_ciudadano)
        {
            ICiudadanosCategoriasDao ciudadanosCategoriasDao = new CiudadanosCategoriasDaoImpl();

            (List<DCiudadanosCategorias> listaCiudadanosCategorias, string errorResponse) = await ciudadanosCategoriasDao.retornarListaCategoriasHistoricasXCiudadano(id_ciudadano);


            return (listaCiudadanosCategorias, errorResponse);

        }
        //FIN RETORNAR LISTA CATEGORIAS DEL CIUDADANO XID..................................

    }
}

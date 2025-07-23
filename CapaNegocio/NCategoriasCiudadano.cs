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
    public class NCategoriasCiudadano
    {
        //RETORNAR CATEGORIAS CIUDADANO TODOS
        public async Task<(List<DCategoriasCiudadano>, string errorResponse)> RetornarListaCategoriasCiudadano()
        {
            ICategoriasCiudadanoDao categoriasCiudadanoDao = new CategoriasCiduadanoDaoImpl();
            //Realizar este metodo mañana para completar los metodos de programa ciudadanos
            (List<DCategoriasCiudadano> listaCategoriasCiudadanos, string errorResponse) = await categoriasCiudadanoDao.retornarListaCategoriasCiudadano();


            return (listaCategoriasCiudadanos, errorResponse);
        }
        //FIN RETORNAR CATEGORIAS CIUDADANO TODOS..................................
    }
}

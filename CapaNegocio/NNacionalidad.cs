using CapaDatos;
using DAO;
using DAOImplement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CapaNegocio
{
    public class NNacionalidad
    {
        //RETORNAR NACIONALIDAD TODOS
        public async Task<(List<DNacionalidad>, string error)> RetornarListaNacionalidad()
        {
            INacionalidadDao nacionalidadDao = new NacionalidadDaolmpl();

            (List<DNacionalidad> listaNacionalidad, string errorResponse) = await nacionalidadDao.retornarListaNacionalidad();
            


            return (listaNacionalidad, errorResponse);
        }
        //FIN RETORNAR NACIONALIDAD TODOS..................................

    }
}

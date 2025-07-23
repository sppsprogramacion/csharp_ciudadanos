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
    public class NMunicipio
    {//inicio clase
        //RETORNAR PAIS TODOS
        public async Task<(List<DMunicipio>, string error)> RetornarListaMunicipioXDepartamento(int departamento_id)
        {
            IMunicipioDao municipioDao = new MunicipioDaolmpl();

            (List<DMunicipio> listaMunicipio, string errorResponse) = await municipioDao.retornarListaMunicipioXDepartamento(departamento_id);


            return (listaMunicipio, errorResponse);
        }
    }//fin clase
}
//RETORNAR PAIS TODOS

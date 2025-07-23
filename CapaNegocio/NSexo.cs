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
    public class NSexo
    {

        //RETORNAR SEXO TODOS
        public async Task<(List<DSexo>, string error)> RetornarListaSexo()
        {
            ISexoDao sexoDao = new SexoDaoImpl();

            (List<DSexo> listaSexo, string errorResponse) = await sexoDao.retornarListaSexo();

            
            return (listaSexo, errorResponse);

        }
        //FIN RETORNAR SEX TODOS..................................
    }
}

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
    public class NParentesco
    {
        //RETORNAR PARENTESCO TODOS
        public async Task<(List<DParentesco>, string error)> retornarListaParentesco()
        {
            IParentescoDao parentescoDao = new ParentescoDaoImpl();

            (List<DParentesco> listaParentesco, string errorResponse) = await parentescoDao.retornarListaParentesco();
           
            return (listaParentesco, errorResponse);
        }
        //FIN RETORNAR PARENTESCO TODOS..................................


        //RETORNAR PARENTESCOS MENOR TODOS
        public async Task<(List<DParentescoMenor>, string error)> retornarListaParentescosMenor()
        {
            IParentescoDao parentescoDao = new ParentescoDaoImpl();

            (List<DParentescoMenor> listaParentescosMEnor, string errorResponse) = await parentescoDao.retornarListaParentescosMenor();

            return (listaParentescosMEnor, errorResponse);
        }
        //FIN RETORNAR PARENTESCOS MENOR TODOS..................................
    }
}

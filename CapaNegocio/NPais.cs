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
    public class NPais
    {//inicio clase
        //RETORNAR PAIS TODOS
        public async Task<(List<DPais>, string error)> RetornarListaPais()
        {
            IPaisDao paisDao = new PaisDaolmpl();
            
            (List<DPais> listaPais, string errorResponse) = await paisDao.retornarListaPais();
            


            return (listaPais, errorResponse);
        }
        //FIN RETORNAR PAIS TODOS..................................
    }//fin clase
}

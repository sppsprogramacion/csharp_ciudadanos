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
    public class NDepartamento
    {//inicio clase
     //RETORNAR PAIS TODOS
        public async Task<(List<Departamento>, string error)> RetornarListaDepartamentoXProvincia(string provincia_id)
        {
            IDepartamentoDao departamentoDao = new DepartamentoDaolmpl();

            (List<Departamento> listaDepartamento, string errorResponse) = await departamentoDao.retornarListaDepartamentoXProvincia(provincia_id);


            return (listaDepartamento, errorResponse);
        }

    }//fin clase
}

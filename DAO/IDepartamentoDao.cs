using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IDepartamentoDao
    {//inicio clase
        int crearDepartamento(Departamento usuario);

        int editarDepartamento(Departamento usuario);

        Departamento buscarDepartamentoXId(int id);

        Task<(List<Departamento>, string error)> retornarListaDepartamentoXProvincia(string provincia_id);
    }//fin clase
}

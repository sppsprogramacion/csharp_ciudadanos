using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IParentescoDao
    { 
        //TRABAJA CON PARENTESCOS DE CIUDADANOS CON INTERNOS Y DE PARENTESCOS ENTRE...
        // ..CIUDADANOS ADULTOS Y CIUDADANOS MENORES

        //PARA CIUDADANOS CON INTERNOS
        DParentesco buscarParentescoXId(int id);

        Task<(List<DParentesco>, string error)> retornarListaParentesco();


        //PARA ADULTOS CON MENORES
        DParentescoMenor buscarParentescoMenorXId(int id);

        Task<(List<DParentescoMenor>, string error)> retornarListaParentescosMenor();
    }
}

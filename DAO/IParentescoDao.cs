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
        DParentesco buscarParentescoXId(int id);

        Task<(List<DParentesco>, string error)> retornarListaParentesco();
    }
}

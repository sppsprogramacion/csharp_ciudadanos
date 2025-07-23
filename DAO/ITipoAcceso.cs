using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface ITipoAcceso
    {
        Task<(List<DTipoAcceso>, string error)> retornarTipoAcceso();
       
    }
}

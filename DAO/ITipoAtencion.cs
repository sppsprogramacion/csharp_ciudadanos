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
    public interface ITipoAtencion
    {
        Task<(List<DTipoAtencion>, string error)> retornarTipoAtencion();
    
    }
}

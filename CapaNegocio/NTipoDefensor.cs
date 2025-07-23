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
    public class NTipoDefensor
    {
        //CREAR TIPO DEFENSOR
        public async Task<(List<DTipoDefensor>, string errorResponse)> MostrarTipoDefensor()
        {
            ITipoDefensorDao tipoDefensorDao = new TipoDefensorDaoImpl();
            //Realizar este metodo mañana para completar los metodos de programa ciudadanos
            (List<DTipoDefensor> listaTipoDefensor, string errorResponse) = await tipoDefensorDao.MostrarTipoDefensor();


            return (listaTipoDefensor, errorResponse);
        }
        //FIN CREAR TIPO DEFENSOR..................................
    }
}

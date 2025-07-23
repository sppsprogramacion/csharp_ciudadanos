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
    public class NOrganismoDestino
    {
        //RETORNAR ORGANISMO DESTINO TODOS
        public async Task<List<DOrganismoDestino>> RetornarOrganismoDestinoTodos()
        {
            IOrganismoDestino organismoDestinoDao = new OrganismoDestinoDaoImpl();

            List<DOrganismoDestino> listaOrganismoDestino = await organismoDestinoDao.retornarOrganismoDestinoTodos();


            return listaOrganismoDestino;
        }
        //FIN RETORNAR ORGANISMO DESTINO TODOS..................................

        //RETORNAR ORGANISMO DESTINO X USUARIO
        public async Task<List<DOrganismoDestino>> retornarOrganismoDestinoListaxUsuario(int id_organismo_destino)
        {
            IOrganismoDestino organismoDestinoDao = new OrganismoDestinoDaoImpl();

            List<DOrganismoDestino> listaOrganismoDestino = await organismoDestinoDao.retornarOrganismoDestinoListaxUsuario(id_organismo_destino);
            //List<DCiudadano> listaCiudadanos = await ciudadanoDao.retornarListaCiudadanoXDni(dni);



            return listaOrganismoDestino;
            
        //FIN ORGANISMO DESTINO X USUARIO..................................

        }


    }
}

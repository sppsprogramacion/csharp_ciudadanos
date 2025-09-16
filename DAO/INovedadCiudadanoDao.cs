using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface INovedadCiudadanoDao
    {
        Task<(DNovedadCiudadano, string error)> CrearNovedadCiudadano(string novedadCiudadano);
        Task<(DNovedadCiudadano, string error)> BuscarNovedadCiudadanoXId(int idNovedad);
        Task<(List<DNovedadCiudadano>, string error)> RetornarNovedadesCiudadanoXCiudadano(int idCiudadano);
    }
}

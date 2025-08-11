using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IMenorACargo
    {
        Task<(DMenorACargo, string error)> CrearMenorACargo(string menorACargo);
        Task<(List<DMenorACargo>, string error)> RetornarListaMenorACargoXCiudadano(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DOrganismoDestino
    {
        public int id_organismo_destino { get; set; }
        public string organismo_destino { get; set; }
        public int organismo_depende { get; set; }
        public bool es_unidad_carcelaria { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DMotivoAtencion
    {
        public int id_motivo_atencion { get; set; }
        public string motivo_atencion { get; set; }
        public int organismo_destino_id { get; set; }

    }
}

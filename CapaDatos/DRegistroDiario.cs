using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DRegistroDiario
    {
        public int id_resgistro_diario { get; set; }
        public int ciudadano_id { get; set; }
        public int tipo_atencion_id { get; set; }
        public int tipo_acceso_id { get; set; }
        public int sector_destino_id { get; set; }
        public int motivo_atencion_id { get; set; }
        public string interno { get; set; }
        public DateTime fecha_ingreso { get; set; }
        //public DateTime hora_ingreso { get; set; }
        //public DateTime hora_egreso { get; set; }
        public string observaciones { get; set; }
    }
}

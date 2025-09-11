using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.AdministrarCiudadano.Datos
{
    public class CiudadanoDatos
    {
        //public int id_ciudadano { get; set; }
        public string txtDni { get; set; }
        public string txtApellido { get; set; }
        public string txtNombre { get; set; }
        public string cmbSexo { get; set; }
        public DateTime dtpickFechaNacimiento { get; set; }
        public string txtTelefono { get; set; }
        public string cmbEstadoCivil { get; set; }
        public string cmbNacionalidad { get; set; }
        public string cmbPais { get; set; }
        public string cmbProvincia { get; set; }
        public string cmbDepartamento { get; set; }
        public string cmbMunicipio { get; set; }
        public string txtCiudad { get; set; }
        public string txtBarrio { get; set; }
        public string txtDireccion { get; set; }
        public string txtNumDomicilio { get; set; }

        //edicion datos personales
        public string txtDetalleMotivo { get; set; }

        //edicion datos domicilio
        public string txtDetalleDomicilio { get; set; }

        //vincular interno con visita
        public string txtIdVisita { get; set; }
        public string txtIdInterno { get; set; }
        public string cmbParentesco { get; set; }

        //asignar como visita
        public string txtAsignarVisitaDetalle { get; set; }

        //establecer discapacidad
        public string txtEstablecerDiscapacidad { get; set; }

        //Quitar categoria
        public string txtDetalleCategoriaQuitar { get; set; }

        //Quitar menores a cargo
        public string txtDetalleMenores { get; set; }

    }
}

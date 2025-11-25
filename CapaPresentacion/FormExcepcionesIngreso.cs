using CapaDatos;
using CapaNegocio;
using CapaPresentacion.Validaciones.AdminVisita.ValidacionProhibicion;
using CapaPresentacion.Validaciones;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormExcepcionesIngreso : Form
    {
        private ErrorProvider errorProvider = new ErrorProvider();

        //cumplimentar/anular excepcion
        bool accionCumplimentarExcepcion = false;
        bool accionAnularExcepcion = false;

        public FormExcepcionesIngreso()
        {
            InitializeComponent();
        }

        private async void btnVerExcepciones_Click(object sender, EventArgs e)
        {
            this.CargarDataGridExcepciones();
        }

        private void dtgvExcepcionesIngreso_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (dtgvExcepcionesIngreso.SelectedRows.Count > 0)
                {
                    int id_excepcion_ingreso;
                    id_excepcion_ingreso = Convert.ToInt32(dtgvExcepcionesIngreso.CurrentRow.Cells["ID"].Value.ToString());

                    if (id_excepcion_ingreso > 0)
                    {
                        txtIdExcepcion.Text = id_excepcion_ingreso.ToString();
                        dtpFechaExcepcion.Value = Convert.ToDateTime(dtgvExcepcionesIngreso.CurrentRow.Cells["FechaExcepcion"].Value.ToString());
                        chkCumplimentadoExcepcion.Checked = Convert.ToBoolean(dtgvExcepcionesIngreso.CurrentRow.Cells["Cumplimentado"].Value.ToString());
                        txtOrganismoExepcion.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["Organismo"].Value.ToString();
                        txtUsuarioCargaExcepcion.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["Usuario"].Value.ToString();
                        txtVisita.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["Visita"].Value.ToString();
                        txtDniVisita.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["DniVisita"].Value.ToString();
                        txtInternoExcepcion.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["Interno"].Value.ToString();
                        txtMotivoExcepcion.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["MotivoExcepcion"].Value.ToString();
                        txtDetalleExcepcion.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["Detalle"].Value.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una excepcion.", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
                             

        


        //METODO PARA OBTENER LA LISTA DE EXCEPCIONES Y CARGARLO EN UN DATA GRID
        async private void CargarDataGridExcepciones()
        {
            NExcepcionIngresoVisita nExcepcionIngresoVisita = new NExcepcionIngresoVisita();
            (List<DExcepcionIngresoVisita> listaExcepcionesIngreso, string errorResponse) = await nExcepcionIngresoVisita.ListaExcepcionesIngresoXFecha(dtpFechaInicioExcepcion.Value.ToString("yyyy-MM-dd"), dtpFechaFinExcepcion.Value.ToString("yyyy-MM-dd"));

            if (listaExcepcionesIngreso == null)
            {
                MessageBox.Show(errorResponse, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var datosfiltrados = listaExcepcionesIngreso
                .Select(c => new
                {
                    Id = c.id_excepcion_ingreso_visita,
                    Visita = c.ciudadano.apellido + " " + c.ciudadano.nombre,
                    DniVisita = c.ciudadano.dni,
                    Interno = c.interno.apellido + " " + c.interno.nombre,
                    MotivoExcepcion = c.motivo,
                    FechaExcepcion = c.fecha_excepcion,
                    Cumplimentado = c.cumplimentado,
                    Detalle = c.detalle_excepcion,
                    Controlado = c.controlado,
                    FechaCarga = c.fecha_carga,
                    Organismo = c.organismo.organismo,
                    Usuario = c.usuario_carga.apellido + " " + c.usuario_carga.nombre                    

                })
                .ToList();

            dtgvExcepcionesIngreso.DataSource = datosfiltrados;

            if (listaExcepcionesIngreso.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                dtgvExcepcionesIngreso.Columns[0].Width = 80;
                dtgvExcepcionesIngreso.Columns[1].Width = 200;
                dtgvExcepcionesIngreso.Columns[2].Width = 100;
                dtgvExcepcionesIngreso.Columns[3].Width = 200;
                dtgvExcepcionesIngreso.Columns[4].Width = 150;
            }
        }
    }
}

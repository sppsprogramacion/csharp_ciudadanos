using CapaDatos;
using CapaNegocio;
using CapaPresentacion.FuncionesGenerales;
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
    public partial class FormProhibicionesAnticipadas : Form
    {
        public FormProhibicionesAnticipadas()
        {
            InitializeComponent();
        }

        private void FormProhibicionesAnticipadas_Load(object sender, EventArgs e)
        {
            //// Ajustar el tamaño del formulario            
            FormularioAyudas.AjustarFormulario(this);
        }
       
        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtApellido.Text == "")
            {
                MessageBox.Show("Debe ingresar el apellido a buscar (minimo 2 caracteres)", "Restricion Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NProhibicionVisitaAnticipada nProhibiciones = new NProhibicionVisitaAnticipada();
            (List<DProhibicionAnticipada> listaProhibiciones, string errorResponse) = await nProhibiciones.ListaProhibicionesXApellido(txtApellido.Text);

            if (listaProhibiciones == null)
            {
                MessageBox.Show(errorResponse, "Restricion Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var datosFiltrados = listaProhibiciones
                .Select(c => new
                {
                    ID = c.id_prohibicion_anticipada,
                    Apellido = c.apellido_visita,
                    Nombre = c.nombre_visita,
                    DNI = c.dni_visita,
                    Sexo = c.sexo.sexo,
                    Vigente = c.vigente

                })
                .ToList();

            dtgvProhibicionesAnticipadas.DataSource = datosFiltrados;

            if (listaProhibiciones.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                dtgvProhibicionesAnticipadas.Columns[0].Width = 90;
                dtgvProhibicionesAnticipadas.Columns[1].Width = 200;
                dtgvProhibicionesAnticipadas.Columns[2].Width = 200;
                dtgvProhibicionesAnticipadas.Columns[3].Width = 90;
                dtgvProhibicionesAnticipadas.Columns[4].Width = 90;
                dtgvProhibicionesAnticipadas.Columns[5].Width = 90;
            }

        }

        private async void dtgvProhibicionesAnticipadas_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                int idProhibicionAnticipada = Convert.ToInt32(dtgvProhibicionesAnticipadas.CurrentRow.Cells["ID"].Value.ToString());

                if (dtgvProhibicionesAnticipadas.SelectedRows.Count > 0)
                {
                    if (idProhibicionAnticipada < 0)
                    {
                        MessageBox.Show("Debe seleccionar una prohibición.");
                        return;
                    }

                    //buscar prohibicion
                    NProhibicionVisitaAnticipada nProhibicion = new NProhibicionVisitaAnticipada();
                    (DProhibicionAnticipada dProhibicionX, string errorResponse) = await nProhibicion.BuscarProhibicionXId(idProhibicionAnticipada);

                    if (dProhibicionX == null)
                    {
                        MessageBox.Show(errorResponse, "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    //cargar prohibicion en formulario
                    txtIdProhibicionAnticipada.Text = dProhibicionX.id_prohibicion_anticipada.ToString();
                    txtApellidoVisita.Text = dProhibicionX.apellido_visita;
                    txtNombreVisita.Text = dProhibicionX.nombre_visita;
                    txtDniVisita.Text = dProhibicionX.dni_visita.ToString();
                    txtSexo.Text = dProhibicionX.sexo.sexo;
                    txtDetalleProhibicionAnticipada.Text = dProhibicionX.detalle;
                    txtApellidoInterno.Text = dProhibicionX.apellido_interno;
                    txtNombreInterno.Text = dProhibicionX.nombre_interno;
                    dtpFechaInicio.Value = dProhibicionX.fecha_inicio;
                    dtpFechaFin.Value = dProhibicionX.fecha_fin;
                    txtTipoLevantamiento.Text = dProhibicionX.tipo_levantamiento;
                    txtFechaProhibicion.Text = dProhibicionX.fecha_prohibicion.ToShortDateString();
                    chkExInterno.Checked = dProhibicionX.is_exinterno;
                    chkProhibicionVigente.Checked = dProhibicionX.vigente;
                    txtUsuarioAlta.Text = dProhibicionX.usuario.apellido + " " + dProhibicionX.usuario.nombre;
                    txtOrganismoAlta.Text = dProhibicionX.organismo.organismo;
                }
            }
        }
    }
}

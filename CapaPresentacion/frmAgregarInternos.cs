using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion;
using CapaPresentacion.FuncionesGenerales;

namespace CapaPresentacion
{
    public partial class frmAgregarInternos : Form
    {
        public int idInternoGlobal { get; set; }
        public frmAgregarInternos()
        {
            InitializeComponent();
        }

        private async void btnBuscarInterno_Click(object sender, EventArgs e)
        {
            NInterno nInternos = new NInterno();
            string apellido_ciudadanos = Convert.ToString(this.txtBuscarInterno.Text);
            (List<DInterno> listaInternos, string errorResponse) = await nInternos.RetornarListaInternoXapellido(apellido_ciudadanos);
            if (listaInternos == null)
            {
                MessageBox.Show(errorResponse, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var datosFiltrados = listaInternos
                .Select(c => new
                {
                    id_interno = c.id_interno,
                    Apellido = c.apellido,
                    Nombre = c.nombre,
                    Prontuario = c.prontuario,
                    Sexo = c.sexo.sexo
                })
                .ToList();

            dgvDatosInternos.DataSource = datosFiltrados;

        }

        public async void dgvDatosInternos_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                this.idInternoGlobal = 1;
                if (dgvDatosInternos.SelectedRows.Count > 0)
                {
                    if (this.idInternoGlobal > 0)
                    {//inicio if

                        this.txtProntuarioInterno.Text = Convert.ToString(this.dgvDatosInternos.CurrentRow.Cells["prontuario"].Value);
                        this.txtApellidoInterno.Text = Convert.ToString(this.dgvDatosInternos.CurrentRow.Cells["apellido"].Value);
                        this.txtNombreInterno.Text = Convert.ToString(this.dgvDatosInternos.CurrentRow.Cells["nombre"].Value);





                    }//fin if
                    else
                    {
                        MessageBox.Show("Debe seleccionar un interno.");
                    }
                }
            }
        }

        public void btnEnviarDatosInternos_Click(object sender, EventArgs e)
        {  
            frmRegistroDiario registroDiario = new frmRegistroDiario();
            AddOwnedForm(registroDiario);
            registroDiario.txtBuscarInternos.Text = Convert.ToString(this.dgvDatosInternos.CurrentRow.Cells["apellido"].Value);
            MessageBox.Show(Convert.ToString(this.dgvDatosInternos.CurrentRow.Cells["apellido"].Value));
            registroDiario.Show();
            //this.Close();
        }

        private void frmAgregarInternos_Load(object sender, EventArgs e)
        {
            //// Ajustar el tamaño del formulario            
            FormularioAyudas.AjustarFormulario(this);
        }
    }
}

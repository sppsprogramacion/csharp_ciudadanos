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

namespace CapaPresentacion
{
    public partial class frmInternosBuscar : Form
    {
        public string IdInternoSeleccionado { get; private set; }
        public string InternoSeleccionado { get; private set; }


        public frmInternosBuscar()
        {
            InitializeComponent();
        }

        private async void btnBuscarApellido_Click(object sender, EventArgs e)
        {
            NInterno nInternos = new NInterno();
            string apellido_ciudadanos = Convert.ToString(this.txtBuscarApellidoInternos.Text);
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
                    Interno = c.apellido + " " + c.nombre,
                    Prontuario = c.prontuario,
                    Sexo = c.sexo.sexo

                })
                .ToList();

            dtvInternos.DataSource = datosFiltrados;

            if (listaInternos.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                dtvInternos.Columns[0].Width = 40;
                dtvInternos.Columns[1].Width = 300;
            }
        }

        private void dtvInternos_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (dtvInternos.SelectedRows.Count > 0)
                {
                    IdInternoSeleccionado = Convert.ToString(this.dtvInternos.CurrentRow.Cells["id_interno"].Value);
                    InternoSeleccionado = Convert.ToString(this.dtvInternos.CurrentRow.Cells["interno"].Value);

                    this.DialogResult = DialogResult.OK; // Para indicar que cerró bien
                    this.Close();

                }//fin if
                else
                {
                    MessageBox.Show("Debe seleccionar un interno.");
                }

            }
        }
    }
}

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
    public partial class AgregarInternos : Form
    {
        public AgregarInternos()
        {
            InitializeComponent();
        }

        private async void txtBuscarInterno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {//inicio if

                NInterno nInternos = new NInterno();
                string apellido_internos = Convert.ToString(this.txtBuscarInterno.Text);
                (List<DInterno> listaInternos, string errorResponse) = await nInternos.RetornarListaInternoXapellido(apellido_internos);
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

                dgvSeleccionarInternos.DataSource = datosFiltrados;

               

                this.Close();
                






            }//fin if
        }

        private void AgregarInternos_Load(object sender, EventArgs e)
        {

        }
    }
}

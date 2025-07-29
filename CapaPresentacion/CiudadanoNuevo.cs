using CapaDatos;
using CapaNegocio;
using CapaPresentacion.Validaciones.Login.Datos;
using CapaPresentacion.Validaciones.Login.ValidacionLogin;
using CapaPresentacion.Validaciones.NuevoCiudadano.Datos;
using CapaPresentacion.Validaciones.NuevoCiudadano.ValidacionNuevoCiudadano;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class CiudadanoNuevo : Form
    {
        //VARIABLES GLOBALES
        private ErrorProvider errorProvider = new ErrorProvider();


        //this.dataListadoCiudadanos.DataSource = NProducto.Buscar(this.txtBuscar.Text);
        //variable global id_ciudadano
        public int idCiudadanoGlobal { get; set; }
        

        private void CiudadanoNuevo_Load(object sender, EventArgs e)
        {
            //Carga de combo sexo
            //NSexo nSexo = new NSexo();

            //cmbSexo.ValueMember = "id_sexo";
            //cmbSexo.DisplayMember = "sexo";
            //List<DSexo> listaSexo = await nSexo.RetornarListaSexo();
            //cmbSexo.DataSource = listaSexo;

            //Carga de combo pais
            //NPais nPais = new NPais();

            //cmbPais.ValueMember = "id_pais";
            //cmbPais.DisplayMember = "pais";
            //List<DPais> listaPais = await nPais.RetornarListaPais();
            //cmbPais.DataSource = listaPais;

            //Carga de combo estado civil
            //NCiudadano nCiudadano = new NCiudadano();

            //cmbBuscarCiudadano.ValueMember = "id_ciudadano";
            //cmbBuscarCiudadano.DisplayMember = "apellido";
            //List<DCiudadano> listaCiudadano = await nCiudadano.RetornarListaCiudadanos();
            //Console.WriteLine(listaCiudadano);

            //cmbBuscarCiudadano.DataSource = listaCiudadano;

            //NCiudadano nCiudadanos = new NCiudadano();
            //List<DCiudadano> listaCiudadanos = new List<DCiudadano>();
            //listaCiudadanos = await nCiudadano.RetornarListaCiudadanos();
            //dataListadoCiudadanos.DataSource = listaCiudadanos;
        }

        public CiudadanoNuevo()
        {
            InitializeComponent();
        }

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //precioando con el mouse haciendo clic no hace nada


        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {



            //AL HACER DOBLE CLIC MOSTRAR EL TRAMITE

            MessageBox.Show("Entrando al doble click");
                //this.idCiudadanoGlobal = Convert.ToInt32(dataListadoCiudadanos.CurrentRow.Cells["id_ciudadano"].Value.ToString());

                //if (dataListadoCiudadanos.SelectedRows.Count > 0)
                //{
                //    if (this.idCiudadanoGlobal > 0)
                //    {
                //    frmAdministrarCiudadadno FAdministrarCiudadanosa = new frmAdministrarCiudadadno();
                //    FAdministrarCiudadanosa.ShowDialog();
                //    }
                //    else
                //    {
                //        MessageBox.Show("Debe seleccionar un ciudadano.");
                //    }
                //}
            




        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmNuevo FNuevo = new frmNuevo();
            FNuevo.ShowDialog();
        }

        private void btnAdministrarCiudadano_Click(object sender, EventArgs e)
        {
            //frmAdministrarCiudadadno FAdministrarCiudadano = new frmAdministrarCiudadadno();
            //FAdministrarCiudadano.Show();
            MessageBox.Show("No funciona este boton");
            this.Close();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            //limpiar errores de provider
            errorProvider.Clear();

            //validar
            var data = new CiudadanoNuevoDatos
            {
                txtBuscarDni = txtBuscarDni.Text
            };

            var validator = new BuscarDniValidator();
            var result = validator.Validate(data);

            if (!result.IsValid)
            {
                MessageBox.Show("Complete correctamente los campos del formulario", "Atencion Ciudadanos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                foreach (var failure in result.Errors)
                {

                    Control control = Controls.Find(failure.PropertyName, true)[0];
                    errorProvider.SetError(control, failure.ErrorMessage);
                }
                return;
            }
            //fin validar


            NCiudadano nCiudadanos = new NCiudadano();

            int dni_ciudadanos = Convert.ToInt32(this.txtBuscarDni.Text);
            (List<DCiudadano> listaCiudadanos, string errorResponse) = await nCiudadanos.RetornarListaCiudadanosXdni(dni_ciudadanos);
            if (listaCiudadanos == null)
            {
                MessageBox.Show(errorResponse, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var datosFiltrados = listaCiudadanos
                .Select(c => new
                {
                    id_ciudadano = c.id_ciudadano,
                    Apellido = c.apellido,
                    Nombre = c.nombre,
                    DNI = c.dni,
                    Sexo = c.sexo.sexo
                })
                .ToList();


            dataListadoCiudadanos.DataSource = datosFiltrados;

        }

        private async void dataListadoCiudadanos_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                this.idCiudadanoGlobal = Convert.ToInt32(dataListadoCiudadanos.CurrentRow.Cells["id_ciudadano"].Value.ToString());

                if (dataListadoCiudadanos.SelectedRows.Count > 0)
                {
                    if (this.idCiudadanoGlobal > 0)
                    {
                        frmAdministrarCiudadadno formAdminVisita = new frmAdministrarCiudadadno();
                        formAdminVisita.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un ciudadano.");
                    }
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //limpiar errores de provider
            errorProvider.Clear();

            //validar
            var data = new CiudadanoNuevoDatos
            {
                txtBuscarApellido = txtBuscarApellido.Text
            };

            var validator = new BuscarApellidoValidator();
            var result = validator.Validate(data);

            if (!result.IsValid)
            {
                MessageBox.Show("Complete correctamente los campos del formulario", "Atencion Ciudadanos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                foreach (var failure in result.Errors)
                {

                    Control control = Controls.Find(failure.PropertyName, true)[0];
                    errorProvider.SetError(control, failure.ErrorMessage);
                }
                return;
            }
            //fin validar

            NCiudadano nCiudadanos = new NCiudadano();

            string apellido_ciudadanos = Convert.ToString(this.txtBuscarApellido.Text);
            (List<DCiudadano> listaCiudadanos, string errorResponse) = await nCiudadanos.RetornarListaCiudadanosXapellido(apellido_ciudadanos);
            if (listaCiudadanos == null)
            {
                MessageBox.Show(errorResponse, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var datosFiltrados = listaCiudadanos
                .Select(c => new
                {
                    id_ciudadano = c.id_ciudadano,
                    Apellido = c.apellido,
                    Nombre = c.nombre,
                    DNI = c.dni,
                    Sexo = c.sexo.sexo
                })
                .ToList();


            dataListadoCiudadanos.DataSource = datosFiltrados;

            if (listaCiudadanos.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                dataListadoCiudadanos.Columns[1].Width = 200;
                dataListadoCiudadanos.Columns[1].Width = 200;
            }

        }
    }
}

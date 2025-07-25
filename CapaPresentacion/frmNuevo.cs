using CapaDatos;
using CapaNegocio;
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
//para combo box dependientes
using System.Data.SqlClient;
using CapaPresentacion.Validaciones.AdministrarCiudadano.Datos;
using CapaPresentacion.Validaciones.AdministrarCiudadano.ValidacionCiudadano;

namespace CapaPresentacion
{
    public partial class frmNuevo : Form
    {//inicio clase
        //para validaciones
        private ErrorProvider errorProvider = new ErrorProvider();

        public frmNuevo()
        {
            InitializeComponent();
        }

        //limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtApellido.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDni.Text = string.Empty;
            this.cmbSexo.Text = string.Empty;
            this.dtpickFechaNacimiento.Text = string.Empty;
            this.cmbEstadoCivil.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.cmbNacionalidad.Text = string.Empty;
            this.cmbPais.Text = string.Empty;
            this.cmbProvincia.Text = string.Empty;
            this.cmbDepartamento.Text = string.Empty;
            this.cmbMunicipio.Text = string.Empty;
            this.txtCiudad.Text = string.Empty;
            this.txtBarrio.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtNumDomicilio.Text = string.Empty;
           

        }

        async private void btnGuardar_Click(object sender, EventArgs e)
        {
            NCiudadano nCiudadano = new NCiudadano();

            List<DCiudadano> listaCiudadanos = new List<DCiudadano>();

            dataGridView1.DataSource = listaCiudadanos;

            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            var datosFormulario = new CiudadanoDatos
            {
                txtDni = txtDni.Text,
                txtApellido = txtApellido.Text,
                txtNombre = txtNombre.Text,
                dtpickFechaNacimiento = dtpickFechaNacimiento.Value,
                cmbSexo = Convert.ToInt32(cmbSexo.SelectedValue.ToString()),
                cmbEstadoCivil = Convert.ToInt32(cmbEstadoCivil.SelectedValue.ToString()),
                txtTelefono = txtTelefono.Text,
                cmbNacionalidad = cmbNacionalidad.SelectedValue.ToString(),
                cmbPais = cmbPais.SelectedValue.ToString(),
                cmbProvincia = cmbProvincia.SelectedValue.ToString(),
                cmbDepartamento = cmbDepartamento.SelectedValue.ToString(),
                cmbMunicipio = cmbMunicipio.SelectedValue.ToString(),
                txtCiudad = txtCiudad.Text,
                txtBarrio = txtBarrio.Text,
                txtDireccion = txtDireccion.Text,
                txtNumDomicilio = txtNumDomicilio.Text,
            };

            var validator = new NuevoCiudadanoValidator();
            var result = validator.Validate(datosFormulario);

            if (!result.IsValid)
            {
                MessageBox.Show("Complete correctamente los campos del formulario", "Atencion al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                foreach (var failure in result.Errors)
                {
                    Control control = Controls.Find(failure.PropertyName, true)[0];
                    errorProvider.SetError(control, failure.ErrorMessage);
                }
                return;
            }

            var data = new
            {
                dni = Convert.ToInt32(txtDni.Text),               
                apellido = txtApellido.Text,
                nombre = txtNombre.Text,
                sexo_id = Convert.ToInt32(cmbSexo.SelectedValue.ToString()),
                estado_civil_id = Convert.ToInt32(cmbEstadoCivil.SelectedValue.ToString()),
                telefono = txtTelefono.Text,
                fecha_nac = dtpickFechaNacimiento.Value,
                nacionalidad_id = Convert.ToString(cmbNacionalidad.SelectedValue.ToString()),
                pais_id = cmbPais.SelectedValue.ToString(),
                provincia_id = cmbProvincia.SelectedValue.ToString(),
                departamento_id = Convert.ToInt32(cmbDepartamento.SelectedValue.ToString()),
                municipio_id = Convert.ToInt32(cmbMunicipio.SelectedValue.ToString()),
                ciudad = txtCiudad.Text,
                barrio = txtBarrio.Text,
                direccion = txtDireccion.Text,
                numero_dom = Convert.ToInt32(txtNumDomicilio.Text)

            };

            string dataCiudadano = JsonConvert.SerializeObject(data);

            try
            {
                //HttpResponseMessage httpResponse = await nCiudadano.crearCiudadano(dataCiudadano);
                (DCiudadano ciudadano, string errorCidadano) = await nCiudadano.crearCiudadano(dataCiudadano);


                if (ciudadano != null)
                {

                    MessageBox.Show("Ciudadano creado correctamente", "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Limpiar();


                    NCiudadano nCiudadanos = new NCiudadano();
                    (List<DCiudadano> listaCiudadanoss, string errorResponse) = await nCiudadanos.RetornarListaCiudadanos();
                    if (listaCiudadanoss == null)
                    {
                        MessageBox.Show(errorResponse, "Atencion al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    dataGridView1.DataSource = listaCiudadanoss;


                }
                else
                {
                    //MessageBox.Show("Revisar codigo" + " " + txtIdCioudadanoCategoria.Text + " " + Convert.ToInt32(2));
                    MessageBox.Show(errorCidadano, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                // Manejo de otros tipos de errores MySQL
                MessageBox.Show("Error: " + ex.Message);
            }

           
        }

        async private void frmNuevo_Load(object sender, EventArgs e)
        {
            //Carga de combo sexo
            NSexo nSexo = new NSexo();

            cmbSexo.ValueMember = "id_sexo";
            cmbSexo.DisplayMember = "sexo";
            (List<DSexo> listaSexo, string errorResponse) = await nSexo.RetornarListaSexo();
            cmbSexo.DataSource = listaSexo;

            //Carga de combo nacionalidad
            NNacionalidad nNacionalidad = new NNacionalidad();

            cmbNacionalidad.ValueMember = "id_nacionalidad";
            cmbNacionalidad.DisplayMember = "nacionalidad";
            (List<DNacionalidad> listaNacionalidad, string errorResponseNacionalidad) = await nNacionalidad.RetornarListaNacionalidad();
            cmbNacionalidad.DataSource = listaNacionalidad;

            //Carga de combo pais
            NPais nPais = new NPais();

            cmbPais.ValueMember = "id_pais";
            cmbPais.DisplayMember = "pais";
            (List<DPais> listaPais, string error)  = await nPais.RetornarListaPais();
            cmbPais.DataSource = listaPais;

            //Carga de combo estado civil
            NEstadoCivil nEstadoCivil = new NEstadoCivil();

            cmbEstadoCivil.ValueMember = "id_estado_civil";
            cmbEstadoCivil.DisplayMember = "estado_civil";
            (List<DEstadoCivil> listaEstadoCivil, string errorResponseEstadoCivil) = await nEstadoCivil.RetornarListaEstadoCivil();
            Console.WriteLine(listaEstadoCivil);

            cmbEstadoCivil.DataSource = listaEstadoCivil;

           

        }

        async void cmbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Carga de combo provincia
            NProvincia nProvincia = new NProvincia();
            string id_paiss = Convert.ToString(this.cmbPais.SelectedValue); 
            cmbProvincia.ValueMember = "id_provincia";
            cmbProvincia.DisplayMember = "provincia";
            (List<DProvincia> listaProvincia, string errorResponseProvincia) = await nProvincia.RetornarListaProvinciasXPais(id_paiss);
            //MessageBox.Show("el paramentro es: " + id_paiss);
            cmbProvincia.DataSource = listaProvincia;
            //MessageBox.Show("presiono el combobox pais");
        }

        async void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Carga de combo departamento
            NDepartamento nDepartamento = new NDepartamento();
            string provincia_identificador = Convert.ToString(this.cmbProvincia.SelectedValue);
            cmbDepartamento.ValueMember = "id_departamento";
            cmbDepartamento.DisplayMember = "departamento";
            (List<Departamento> listaDepartamento, string errorResponseDepartamento) = await nDepartamento.RetornarListaDepartamentoXProvincia(provincia_identificador);
            //MessageBox.Show("el paramentro es: " + provincia_identificador);
            cmbDepartamento.DataSource = listaDepartamento;
        }

        async void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Carga de combo departamento
            NMunicipio nMunicipio = new NMunicipio();
            int departamento_identificador = Convert.ToInt32(this.cmbDepartamento.SelectedValue);
            cmbMunicipio.ValueMember = "id_municipio";
            cmbMunicipio.DisplayMember = "municipio";
            (List<DMunicipio> listaMunicipio, string errorRespnseMunicipio) = await nMunicipio.RetornarListaMunicipioXDepartamento(departamento_identificador);
            //MessageBox.Show("el paramentro es: " + departamento_identificador);
            cmbMunicipio.DataSource = listaMunicipio;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.isEditar = false;
            //this.isNuevo = false;
            this.Limpiar();
            //this.Habilitar(false);
            //this.Botones();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            CiudadanoNuevo FCiudadanoNuevo = new CiudadanoNuevo();
            FCiudadanoNuevo.ShowDialog();
        }

        private void cmbDepartamento_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("cambio el valor del comobobox");
        }
    }//fin clase

}


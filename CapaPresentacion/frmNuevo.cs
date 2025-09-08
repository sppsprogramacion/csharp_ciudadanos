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
using CapaPresentacion.FuncionesGenerales;
using System.Drawing.Printing;
using System.IO;
using System.Xml.Linq;

using iTextSharp.text;//librerias para trabajar con reportes
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;//libreria para el guardado de los archivos

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


            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            var datosFormulario = new CiudadanoDatos
            {
                txtDni = txtDni.Text,
                txtApellido = txtApellido.Text,
                txtNombre = txtNombre.Text,
                dtpickFechaNacimiento = dtpickFechaNacimiento.Value,
                cmbSexo = cmbSexo.SelectedValue.ToString(),
                cmbEstadoCivil = cmbEstadoCivil.SelectedValue.ToString(),
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
            //fin validar formulario....................

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

                    //SaveFileDialog solicita al usuario que busqeu un lugar para guardar un archivo
                    SaveFileDialog guardar = new SaveFileDialog();
                    guardar.FileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";//gaurda el archivo con el nombre de la fecha del dia concatenado con la hora .pdf
                                                                                        //guardar.ShowDialog();//ejecuta un cuadro de dialogo

                    /*La forma para trabajar u archivo .pdf, o al menos el diseño que va a tener el pdf, en el video lo trabajan 
                    es en que se puedan cambiar y modificar por un largo tiempo. La forma es creando un archivo html, en donde se diseña una tabla
                    con el ancho de las columnas y todo lo necesarrio para crear las tablas, trabajando totalmente el html, y en base a este archivo
                    generar un pdf*/

                    string paginahtml_texto = Properties.Resources.plantilla.ToString();
                    //vamos a reemplazar los parametros por los valores de los formularios
                    paginahtml_texto = paginahtml_texto.Replace("@DNI", Convert.ToString(data.dni));
                    paginahtml_texto = paginahtml_texto.Replace("@NOMBRE", (data.apellido) + " " + (data.nombre));
                    paginahtml_texto = paginahtml_texto.Replace("@DOMICILIO", (data.direccion) + " " + (data.numero_dom));
                    paginahtml_texto = paginahtml_texto.Replace("@NACIONALIDAD", (data.nacionalidad_id));
                    paginahtml_texto = paginahtml_texto.Replace("@FECHA_ALTA", (data.apellido) + " " + (data.nombre));
                    paginahtml_texto = paginahtml_texto.Replace("@ESTADO_CIVIL", Convert.ToString(data.estado_civil_id));
                    paginahtml_texto = paginahtml_texto.Replace("@NACIMIENTO", Convert.ToString(data.fecha_nac));
                    paginahtml_texto = paginahtml_texto.Replace("@TELEFONO", (data.telefono));
                    
                    //vamos a hacer elguardado del archivo si cumple todos los requisitos
                    if (guardar.ShowDialog() == DialogResult.OK)
                    {
                        //primero vamos a guardar el archivo pdf en un archivo de memoria
                        using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                        {
                            Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25); //archivo .pdf tamaño A4 con margenes de 25 para los lados
                            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                            pdfDoc.Open();//necesitamos abrir el archivo para agregar los textos
                                          //pdfDoc.Add(new Phrase("Hola a todos"));

                            using (StringReader sr = new StringReader(paginahtml_texto))
                            {
                                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                            }

                            pdfDoc.Close();
                            stream.Close();
                        }

                    }

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
            //// Ajustar el tamaño del formulario            
            FormularioAyudas.AjustarFormulario(this);

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
            
            this.Limpiar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbDepartamento_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("cambio el valor del comobobox");
        }
    }//fin clase

}


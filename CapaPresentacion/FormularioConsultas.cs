using CapaDatos;
using CapaNegocio;
using CapaPresentacion.FuncionesGenerales;
using CapaPresentacion.Validaciones.AdministrarCiudadano.Datos;
using CapaPresentacion.Validaciones.AdministrarCiudadano.ValidacionCiudadano;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using CapaPresentacion.Validaciones.AdminVisita.ValidacionProhibicion;
using CapaPresentacion.Reportes.AdministrarCiudadano;
using PdfiumViewer;
using PdfDocument = PdfiumViewer.PdfDocument;
using System.Net;
using CommonCache;
using CapaPresentacion.Reportes.AdministrarRegistroDiario;

namespace CapaPresentacion
{
    public partial class FormularioConsultas : Form
    {

        DCiudadano dCiudadano = new DCiudadano();
        DInterno dInterno = new DInterno();
        public FormularioConsultas()
        {
            InitializeComponent();
        }

        private async void btnImprimirReporte_Click(object sender, EventArgs e)
        {
            //NVisitaInterno nVisitaInterno = new NVisitaInterno();
            NRegistroDiario nRegistroDiario = new NRegistroDiario();
            DRegistroDiario dRegistroDiario = new DRegistroDiario();

            /*string hora_fin;
            String horaSalida = dRegistroDiario.hora_egreso;
            if (string.IsNullOrEmpty(horaSalida))
            {
                //hora_fin = this.dtpHoraInicio.Value.ToString("HH:MM:ss");
                MessageBox.Show("Cadena nula o vacia" + " " + dRegistroDiario.hora_egreso);
            }
            else
            {
                //hora_fin = horaSalida;
                //hora_fin = this.dtpHoraInicio.Value.ToString("HH:MM:ss");
                MessageBox.Show("Cadena con valores ingresados" + " " + horaSalida);
            }
            */

            (List<DRegistroDiario> listaRegistroDiario, string errorResponse) = await nRegistroDiario.retornarListaRegistroDiario(this.dtpFechaInicio.Value.ToString("yyyy-MM-dd"), this.dtpHoraInicio.Value.ToString("HH:MM:ss"), this.dtpHoraFin.Value.ToString("HH:MM:ss"));
            MessageBox.Show("la fecha que ingreso es: " + " " + this.dtpFechaInicio.Value.ToString("yyyy-MM-dd"));
            MessageBox.Show("la de ingreso es: " + " " + this.dtpHoraInicio.Value.ToString("HH:MM:ss"));
            MessageBox.Show("la hora de salida es: " + " " + this.dtpHoraFin.Value.ToString("HH:MM:ss"));
            if (listaRegistroDiario == null)
            {
                MessageBox.Show(errorResponse, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            // Generar PDF en memoria
            MemoryStream msOriginal = ReportesRegistroDiarioxFechaHoraPDF.RepPdfRegistroDiario(this.dCiudadano, this.dInterno, listaRegistroDiario);

            // Clonar el stream para que PdfiumViewer pueda cerrarlo sin afectar el original
            MemoryStream ms = new MemoryStream(msOriginal.ToArray());

            PdfDocument pdfDocument = null;

            try
            {
                pdfDocument = PdfDocument.Load(ms);

                Form formVisor = new Form
                {
                    Text = "Vista previa PDF",
                    Width = 800,
                    Height = 600
                };

                PdfViewer pdfViewer = new PdfViewer
                {
                    Dock = DockStyle.Fill,
                    Document = pdfDocument
                };

                formVisor.Controls.Add(pdfViewer);

                formVisor.FormClosed += (s, args) =>
                {
                    // Liberar recursos al cerrar el visor
                    pdfViewer.Document.Dispose();
                    pdfViewer.Dispose();
                    formVisor.Dispose();
                    ms.Dispose();
                    pdfDocument = null;
                };

                formVisor.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar PDF: " + ex.Message);
                ms.Dispose();
                pdfDocument?.Dispose();
            }
        }

        private async void button4_Click_1(object sender, EventArgs e)
        {
            int idCiudadano;
            //acceder a la instancia de FormTramites abierta.
            CiudadanoNuevo FCiudadanoNuevoDatos = Application.OpenForms["CiudadanoNuevo"] as CiudadanoNuevo;
            CiudadanoNuevo ciudadanoNuevos = new CiudadanoNuevo();
            idCiudadano = Convert.ToInt32(FCiudadanoNuevoDatos.idCiudadanoGlobal);

            NCiudadano nCiudadano = new NCiudadano();
            (DCiudadano dCiudadano2, string errorResponse) = await nCiudadano.BuscarCiudadanoXID(idCiudadano);

            this.dCiudadano = dCiudadano2;

            if (this.dCiudadano == null)
            {
                MessageBox.Show(errorResponse, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            DCiudadano dCiudadano = new DCiudadano();
            //SaveFileDialog solicita al usuario que busqeu un lugar para guardar un archivo
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";//gaurda el archivo con el nombre de la fecha del dia concatenado con la hora .pdf
                                                                                //guardar.ShowDialog();//ejecuta un cuadro de dialogo

            //revisarstring varSexo = Convert.ToString(cmbSexo.Text);
            
            //MessageBox.Show(varSexo);
            /*La forma para trabajar u archivo .pdf, o al menos el diseño que va a tener el pdf, en el video lo trabajan 
            es en que se puedan cambiar y modificar por un largo tiempo. La forma es creando un archivo html, en donde se diseña una tabla
            con el ancho de las columnas y todo lo necesarrio para crear las tablas, trabajando totalmente el html, y en base a este archivo
            generar un pdf*/

            string paginahtml_texto = Properties.Resources.plantilla.ToString();
            //vamos a reemplazar los parametros por los valores de los formularios
            paginahtml_texto = paginahtml_texto.Replace("@DNI", Convert.ToString(dCiudadano2.dni));
            paginahtml_texto = paginahtml_texto.Replace("@NOMBRE", (dCiudadano2.apellido) + " " + (dCiudadano2.nombre));
            paginahtml_texto = paginahtml_texto.Replace("@DOMICILIO", (dCiudadano2.direccion) + " " + (dCiudadano2.numero_dom));
            paginahtml_texto = paginahtml_texto.Replace("@NACIONALIDAD", (dCiudadano2.nacionalidad.nacionalidad));
            paginahtml_texto = paginahtml_texto.Replace("@FECHA_ALTA", Convert.ToString(dCiudadano2.fecha_alta));
            paginahtml_texto = paginahtml_texto.Replace("@ESTADO_CIVIL", Convert.ToString(dCiudadano2.estado_civil.estado_civil));
            paginahtml_texto = paginahtml_texto.Replace("@NACIMIENTO", Convert.ToString(dCiudadano2.fecha_nac));
            paginahtml_texto = paginahtml_texto.Replace("@TELEFONO", (dCiudadano2.telefono));
            paginahtml_texto = paginahtml_texto.Replace("@SEXO", dCiudadano2.sexo.sexo);
            //paginahtml_texto = paginahtml_texto.Replace("@PARENTEZCO", Convert.ToString(data));


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

        private async void btnVerRegistroDiario_Click(object sender, EventArgs e)
        {
            //NVisitaInterno nVisitaInterno = new NVisitaInterno();
            NRegistroDiario nRegistroDiario = new NRegistroDiario();
            //(List<DVisitaInterno> listaVisitasInternos, string errorResponse) = await nVisitaInterno.retornarListaVisitaInternoXCiudadano(Convert.ToInt32(this.txtIdCiudadano.Text));
            (List<DRegistroDiario> listaRegistroDiario, string errorResponse) = await nRegistroDiario.retornarListaRegistroDiario(this.dtpFechaInicio.Value.ToString("yyyy-MM-dd"), this.dtpHoraInicio.Value.ToString("HH:MM:ss"), this.dtpHoraFin.Value.ToString("HH:MM:ss"));
            

            if (listaRegistroDiario == null)
            {
                MessageBox.Show(errorResponse, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var datosFiltrados = listaRegistroDiario
            .Select(c => new
            {
                Ingreso = c.hora_ingreso,
                Egreso = c.hora_egreso,
                Destino = c.organismo.organismo,
                División = c.sector_destino.sector_destino,
                TipoAcceso = c.tipo_atencion.tipo_atencion,
                Motivo = c.motivo_atencion.motivo_atencion,
                Nombre = c.ciudadano.apellido + " " + c.ciudadano.nombre,
                Sexo = c.ciudadano.sexo.sexo,
                Dni = c.ciudadano.dni,
                Interno = c.interno,
                Obs = c.observaciones,
                Operador = c.usuario.apellido + " " + c.usuario.nombre
                


            })
            .ToList();

            dgvRegistroDiario.DataSource = datosFiltrados;

            if (listaRegistroDiario.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                dgvRegistroDiario.Columns[1].Width = 200;
            }
        }

        private void FormularioConsultas_Load(object sender, EventArgs e)
        {

        }
    }
}

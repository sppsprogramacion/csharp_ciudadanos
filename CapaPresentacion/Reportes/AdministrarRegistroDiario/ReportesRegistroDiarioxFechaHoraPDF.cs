using CapaDatos;
using CommonCache;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Reportes.AdministrarRegistroDiario
{
    public class ReportesRegistroDiarioxFechaHoraPDF
    {
        //VINCULOS DE LA VISITA         
        public static MemoryStream RepPdfRegistroDiario(DCiudadano ciudadanox, DInterno internox, List<DRegistroDiario> listaRegistroDiario)
        {
            MemoryStream ms = new MemoryStream();

            Document doc = new Document(PageSize.A4.Rotate(), 50, 50, 50, 50);

            PdfWriter writer = PdfWriter.GetInstance(doc, ms);
            writer.CloseStream = false; // evita cerrar el MemoryStream al cerrar el documento

            doc.Open();

            var fuenteLogo = FontFactory.GetFont(FontFactory.TIMES, 9, BaseColor.BLACK);
            var fuenteOrganismo = FontFactory.GetFont(FontFactory.TIMES, 10, BaseColor.BLACK);
            var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK);
            var fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 6, BaseColor.BLACK);

            //logo encabezado
            //string rutaImagen = Path.Combine(Application.StartupPath, "Resources/Img-reportes/", "logo_spps2.png");
            //iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(rutaImagen);

            // Cargar directamente desde Resources
            System.Drawing.Image logoImg = Properties.Resources.logo_spps2;
            // Convertir a iTextSharp Image
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoImg, System.Drawing.Imaging.ImageFormat.Png);
            string organismo = CurrentUser.Instance.organismo.ToUpper();
            logo.ScaleAbsolute(40, 40);
            logo.SetAbsolutePosition(150, 770);
            doc.Add(logo);
            doc.Add(new Paragraph(" "));

            // Crear tabla con 1 columnas
            PdfPTable tablaEncabezado = new PdfPTable(1);
            tablaEncabezado.WidthPercentage = 50; // ocupa la mitad de la página
            tablaEncabezado.HorizontalAlignment = Element.ALIGN_LEFT; // tabla a la izquierda

            // Centrar contenido de todas las celdas
            tablaEncabezado.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tablaEncabezado.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            tablaEncabezado.DefaultCell.Border = Rectangle.NO_BORDER;

            // Agregar celdas
            tablaEncabezado.AddCell(new Paragraph("  SERVICIO PENITENCIARIO DE LA PROVINCIA DE SALTA", fuenteLogo));
            tablaEncabezado.AddCell(new Paragraph(organismo, fuenteOrganismo));

            // Agregar tabla al documento
            doc.Add(tablaEncabezado);
            //fin logo encabezado.....................................

            //fecha
            DateTime fechaHoy = DateTime.Now;
            CultureInfo cultura = new CultureInfo("es-ES");

            // "d 'de' MMMM 'de' yyyy" → ejemplo: "9 de septiembre de 2025"
            string fechaCompleta = "Salta, " + fechaHoy.ToString("d 'de' MMMM 'de' yyyy", cultura);

            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(fechaCompleta, fuenteLogo)
            {
                Alignment = Element.ALIGN_RIGHT
            });
            //fin fecha.............................

            doc.Add(new Paragraph(" "));

            //datos ciudadano
            //doc.Add(new Paragraph(" Apellido y nombre: " + ciudadanox.apellido + " " + ciudadanox.nombre, fuenteNormal));
            //doc.Add(new Paragraph(" DNI: " + ciudadanox.dni, fuenteNormal));
            PdfPTable tablaDatos = new PdfPTable(2);
            tablaDatos.WidthPercentage = 60;
            tablaDatos.HorizontalAlignment = Element.ALIGN_LEFT; // tabla a la izquierda
            tablaDatos.DefaultCell.Border = Rectangle.NO_BORDER;
            //tablaDatos.AddCell(new Paragraph("Sexo: " + ciudadanox.sexo.sexo, fuenteNormal));
            //tablaDatos.AddCell(new Paragraph("Edad: " + ciudadanox.edad, fuenteNormal));
            //doc.Add(tablaDatos);
            //fin datos ciudadano

            doc.Add(new Paragraph(" "));

            Paragraph titulo = new Paragraph("LIBRO DE REGISTRO DIARIO", fuenteTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            doc.Add(titulo);


            doc.Add(new Paragraph(" "));

            
            PdfPTable tablaRegistrodiario = new PdfPTable(10);
            tablaRegistrodiario.WidthPercentage = 100;
            tablaRegistrodiario.SetWidths(new float[] { 0.4f, 0.8f, 1.0f, 0.6f, 0.6f, 1.2f, 1.0f, 0.4f, 0.4f, 1.0f });
            tablaRegistrodiario.AddCell("Ingreso");
            tablaRegistrodiario.AddCell("Egreso");
            tablaRegistrodiario.AddCell("Destino");
            tablaRegistrodiario.AddCell("División");
            tablaRegistrodiario.AddCell("TAcceso");
            tablaRegistrodiario.AddCell("Motivo");
            tablaRegistrodiario.AddCell("Nombre");
            tablaRegistrodiario.AddCell("Sexo");
            tablaRegistrodiario.AddCell("dni");
            tablaRegistrodiario.AddCell("int");

            // Filas dinámicas
            foreach (var registroDiario in listaRegistroDiario)
            {
                tablaRegistrodiario.AddCell(new Paragraph(registroDiario.hora_ingreso.ToString(), fuenteNormal));
                tablaRegistrodiario.AddCell(new Paragraph(registroDiario.hora_ingreso.ToString(), fuenteNormal));
                tablaRegistrodiario.AddCell(new Paragraph(registroDiario.organismo.organismo.ToString(), fuenteNormal));
                tablaRegistrodiario.AddCell(new Paragraph(registroDiario.sector_destino.sector_destino.ToString(), fuenteNormal));
                tablaRegistrodiario.AddCell(new Paragraph(registroDiario.tipo_atencion.tipo_atencion.ToString(), fuenteNormal));
                tablaRegistrodiario.AddCell(new Paragraph(registroDiario.motivo_atencion.motivo_atencion.ToString(), fuenteNormal));
                tablaRegistrodiario.AddCell(new Paragraph(registroDiario.ciudadano.apellido + " " + registroDiario.ciudadano.nombre, fuenteNormal));
                tablaRegistrodiario.AddCell(new Paragraph(registroDiario.ciudadano.sexo.sexo.ToString(), fuenteNormal));
                tablaRegistrodiario.AddCell(new Paragraph(registroDiario.ciudadano.dni.ToString(), fuenteNormal));
                tablaRegistrodiario.AddCell(new Paragraph(registroDiario.interno.apellido + " " + registroDiario.interno.nombre, fuenteNormal));
            }

            doc.Add(tablaRegistrodiario);

            doc.Close(); // Cierra el documento pero NO el MemoryStream
            ms.Position = 0;

            return ms;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;//se agrega para ls imagenes
using System.Drawing.Printing;//Para funciones de impresiones
using System.Windows.Forms;
//using System.Runtime.InteropServices.ObjectiveC;//Para que se vea los comandos de impresion

namespace CapaPresentacion
{
    public class CrearReporte
    {
        public string espacio1_en_blanco { get; set; }
        public string espacio2_en_blanco { get; set; }
        public string encabezado_principal1 { get; set; }
        public string encabezado_principal2 { get; set; }
        public string encabezado_principal3 { get; set; }
        public string encabezado_secundario1 { get; set; }
        public string encabezado_secundario2 { get; set; }
        public string pie_de_pagina1 { get; set; }
        public string pie_de_pagina2 { get; set; }
        public string pie_de_pagina3 { get; set; }
        public string pie_de_pagina4 { get; set; }
        public string pie_de_pagina5 { get; set; }
        public string pie_de_pagina6 { get; set; }
        public string pie_de_pagina7 { get; set; }
        public string pie_de_pagina8 { get; set; }
        public string nombre { get; set; }
        public string dni { get; set; }
        public string nacionalidad { get; set; }
        public string fecha_nacimiento { get; set; }
        public string sexo { get; set; }
        public string domicilio { get; set; }
        public string telefono { get; set; }
        public string fecha_alta { get; set; }
        public string estado_civil { get; set; }
        public string parentezco_vinculo { get; set; }
        //public Image logotipo { get; set; }

        private PrintDocument doc = new PrintDocument();

        private PrintPreviewDialog vista = new PrintPreviewDialog();

        //metodo para imprimir parametro que es la clase producto
        public void imprimir(CrearReporte p)
        {
            //este codigo va a recibir un parametro "doc.DefaultPageSettings.PrinterSettings.PrinterName" y va a pasarle al PrinterSettting 
            //la imprestora que tiene el usuario poir defecto, si la impresora es de hojas grandes imprime en esa, si tiene una tiquetera imprime en la tiketera
            doc.PrinterSettings.PrinterName = doc.DefaultPageSettings.PrinterSettings.PrinterName;
            //vamos a crear un metodo y se la vamos a asignar al doc. PrintPage 
            doc.PrintPage += new PrintPageEventHandler(imprimeticket);
            vista.Document = doc;//para que nos muestre la vista
            vista.Show();
        }


        public void imprimeticket(object sender, PrintPageEventArgs e)
        {
            //declaramos variables
            int PosX, PosY;
            Font fuente = new Font("consola", 10, FontStyle.Regular);
            Font fuente_fecha = new Font("consola", 10, FontStyle.Regular);
            Font fuente_ciudadano = new Font("consola", 10, FontStyle.Bold);
            Font fuente_interno = new Font("consola", 10, FontStyle.Regular);
            Font fuente_encabezado_principal = new Font("consola", 14, FontStyle.Bold);
            Font fuente_encabezado_secundario = new Font("consola", 12, FontStyle.Regular);

            try
            {

                PosX = 0;
                PosY = 0;
                //e.Graphics.DrawImage(logotipo, 15, 20, 100, 100);
                //PosY += 110;
                e.Graphics.DrawString(espacio1_en_blanco, fuente_fecha, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(espacio2_en_blanco, fuente_fecha, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(encabezado_principal1, fuente_encabezado_principal, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(encabezado_principal2, fuente_encabezado_principal, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(encabezado_principal3, fuente_encabezado_principal, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(espacio1_en_blanco, fuente_fecha, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(espacio1_en_blanco, fuente_fecha, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(encabezado_secundario1, fuente_encabezado_secundario, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(encabezado_secundario2, fuente_encabezado_secundario, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(espacio1_en_blanco, fuente_fecha, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(espacio1_en_blanco, fuente_fecha, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(dni, fuente_fecha, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(nacionalidad, fuente_fecha, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(fecha_nacimiento, fuente_fecha, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(sexo, fuente, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(domicilio, fuente_ciudadano, Brushes.Black, PosX, PosY);
                PosY += 25;
                e.Graphics.DrawString(telefono, fuente_interno, Brushes.Black, PosX, PosY);
                PosY += 25;
                e.Graphics.DrawString(fecha_alta, fuente, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(estado_civil, fuente_ciudadano, Brushes.Black, PosX, PosY);
                PosY += 25;
                e.Graphics.DrawString(espacio1_en_blanco, fuente_fecha, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(espacio2_en_blanco, fuente_fecha, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(pie_de_pagina1, fuente_encabezado_secundario, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(espacio1_en_blanco, fuente_fecha, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(espacio2_en_blanco, fuente_fecha, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(espacio1_en_blanco, fuente_fecha, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(espacio2_en_blanco, fuente_fecha, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(espacio1_en_blanco, fuente_fecha, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(espacio2_en_blanco, fuente_fecha, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(espacio1_en_blanco, fuente_fecha, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(espacio2_en_blanco, fuente_fecha, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(pie_de_pagina2, fuente_encabezado_secundario, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(pie_de_pagina3, fuente_encabezado_secundario, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(pie_de_pagina4, fuente_encabezado_secundario, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(pie_de_pagina5, fuente_encabezado_secundario, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(espacio1_en_blanco, fuente_fecha, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(espacio2_en_blanco, fuente_fecha, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(espacio1_en_blanco, fuente_fecha, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(espacio2_en_blanco, fuente_fecha, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(pie_de_pagina6, fuente_encabezado_secundario, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(pie_de_pagina7, fuente_encabezado_secundario, Brushes.Black, PosX, PosY);
                PosY += 20;
                e.Graphics.DrawString(pie_de_pagina8, fuente_encabezado_secundario, Brushes.Black, PosX, PosY);
                PosY += 20;
                //e.Graphics.DrawString(parentezco_vinculo, fuente_interno, Brushes.Black, PosX, PosY);
                //PosY += 25;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }




        }

    }
}

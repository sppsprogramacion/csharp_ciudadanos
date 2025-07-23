namespace CapaPresentacion
{
    partial class AgregarInternos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtBuscarInterno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSeleccionarInternos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeleccionarInternos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBuscarInterno
            // 
            this.txtBuscarInterno.Location = new System.Drawing.Point(267, 70);
            this.txtBuscarInterno.Name = "txtBuscarInterno";
            this.txtBuscarInterno.Size = new System.Drawing.Size(296, 20);
            this.txtBuscarInterno.TabIndex = 0;
            this.txtBuscarInterno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscarInterno_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ingrese el apellido del interno:";
            // 
            // dgvSeleccionarInternos
            // 
            this.dgvSeleccionarInternos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeleccionarInternos.Location = new System.Drawing.Point(59, 122);
            this.dgvSeleccionarInternos.Name = "dgvSeleccionarInternos";
            this.dgvSeleccionarInternos.Size = new System.Drawing.Size(673, 150);
            this.dgvSeleccionarInternos.TabIndex = 2;
            // 
            // AgregarInternos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 419);
            this.Controls.Add(this.dgvSeleccionarInternos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuscarInterno);
            this.Name = "AgregarInternos";
            this.Text = "Formulario Agregar Nuevos Internos";
            this.Load += new System.EventHandler(this.AgregarInternos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeleccionarInternos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBuscarInterno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSeleccionarInternos;
    }
}
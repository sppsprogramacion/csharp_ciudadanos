namespace CapaPresentacion
{
    partial class FormularioConsultas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioConsultas));
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnImprimirReporte = new System.Windows.Forms.Button();
            this.dtpHoraFin = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVerRegistroDiario = new System.Windows.Forms.Button();
            this.dgvRegistroDiario = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistroDiario)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(291, 70);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(120, 20);
            this.dtpFechaInicio.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnVerRegistroDiario);
            this.panel1.Controls.Add(this.btnImprimirReporte);
            this.panel1.Controls.Add(this.dtpHoraFin);
            this.panel1.Controls.Add(this.dtpHoraInicio);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpFechaInicio);
            this.panel1.Location = new System.Drawing.Point(35, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(542, 307);
            this.panel1.TabIndex = 1;
            // 
            // btnImprimirReporte
            // 
            this.btnImprimirReporte.BackColor = System.Drawing.Color.White;
            this.btnImprimirReporte.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImprimirReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirReporte.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimirReporte.Image")));
            this.btnImprimirReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimirReporte.Location = new System.Drawing.Point(291, 220);
            this.btnImprimirReporte.Name = "btnImprimirReporte";
            this.btnImprimirReporte.Size = new System.Drawing.Size(204, 35);
            this.btnImprimirReporte.TabIndex = 7;
            this.btnImprimirReporte.Text = "Imprimir Reporte";
            this.btnImprimirReporte.UseVisualStyleBackColor = false;
            this.btnImprimirReporte.Click += new System.EventHandler(this.btnImprimirReporte_Click);
            // 
            // dtpHoraFin
            // 
            this.dtpHoraFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraFin.Location = new System.Drawing.Point(291, 156);
            this.dtpHoraFin.Name = "dtpHoraFin";
            this.dtpHoraFin.Size = new System.Drawing.Size(120, 20);
            this.dtpHoraFin.TabIndex = 6;
            // 
            // dtpHoraInicio
            // 
            this.dtpHoraInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraInicio.Location = new System.Drawing.Point(291, 111);
            this.dtpHoraInicio.Name = "dtpHoraInicio";
            this.dtpHoraInicio.Size = new System.Drawing.Size(120, 20);
            this.dtpHoraInicio.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(100, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ingrese hora fin:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(100, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ingrese hora de inicio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(100, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ingrese fecha:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(55, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Imprimir Reporte Registro Diario ";
            // 
            // btnVerRegistroDiario
            // 
            this.btnVerRegistroDiario.BackColor = System.Drawing.Color.White;
            this.btnVerRegistroDiario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVerRegistroDiario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerRegistroDiario.Image = ((System.Drawing.Image)(resources.GetObject("btnVerRegistroDiario.Image")));
            this.btnVerRegistroDiario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerRegistroDiario.Location = new System.Drawing.Point(60, 220);
            this.btnVerRegistroDiario.Name = "btnVerRegistroDiario";
            this.btnVerRegistroDiario.Size = new System.Drawing.Size(215, 35);
            this.btnVerRegistroDiario.TabIndex = 8;
            this.btnVerRegistroDiario.Text = "Listar Registro Diario";
            this.btnVerRegistroDiario.UseVisualStyleBackColor = false;
            this.btnVerRegistroDiario.Click += new System.EventHandler(this.btnVerRegistroDiario_Click);
            // 
            // dgvRegistroDiario
            // 
            this.dgvRegistroDiario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistroDiario.Location = new System.Drawing.Point(35, 356);
            this.dgvRegistroDiario.Name = "dgvRegistroDiario";
            this.dgvRegistroDiario.Size = new System.Drawing.Size(1338, 326);
            this.dgvRegistroDiario.TabIndex = 2;
            // 
            // FormularioConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1385, 694);
            this.Controls.Add(this.dgvRegistroDiario);
            this.Controls.Add(this.panel1);
            this.Name = "FormularioConsultas";
            this.Text = "FormularioConsultas";
            this.Load += new System.EventHandler(this.FormularioConsultas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistroDiario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpHoraFin;
        private System.Windows.Forms.DateTimePicker dtpHoraInicio;
        private System.Windows.Forms.Button btnImprimirReporte;
        private System.Windows.Forms.Button btnVerRegistroDiario;
        private System.Windows.Forms.DataGridView dgvRegistroDiario;
    }
}
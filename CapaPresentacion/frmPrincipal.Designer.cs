namespace CapaPresentacion
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegistroDiario = new System.Windows.Forms.Button();
            this.btnAdministrar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnListaExcepciones = new System.Windows.Forms.Button();
            this.btn_Consultas = new System.Windows.Forms.Button();
            this.btnEgresoCiudadano = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(905, 72);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(283, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sistema de Atención al Ciudadano";
            // 
            // btnRegistroDiario
            // 
            this.btnRegistroDiario.BackColor = System.Drawing.Color.White;
            this.btnRegistroDiario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistroDiario.Font = new System.Drawing.Font("Britannic Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistroDiario.Image = global::CapaPresentacion.Properties.Resources.reportes1;
            this.btnRegistroDiario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistroDiario.Location = new System.Drawing.Point(254, 109);
            this.btnRegistroDiario.Name = "btnRegistroDiario";
            this.btnRegistroDiario.Size = new System.Drawing.Size(178, 65);
            this.btnRegistroDiario.TabIndex = 5;
            this.btnRegistroDiario.Text = "        Registro Diario";
            this.btnRegistroDiario.UseVisualStyleBackColor = false;
            this.btnRegistroDiario.Click += new System.EventHandler(this.btnRegistroDiario_Click);
            // 
            // btnAdministrar
            // 
            this.btnAdministrar.BackColor = System.Drawing.Color.White;
            this.btnAdministrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministrar.Font = new System.Drawing.Font("Britannic Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdministrar.Image = global::CapaPresentacion.Properties.Resources.mantenimiento;
            this.btnAdministrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdministrar.Location = new System.Drawing.Point(70, 109);
            this.btnAdministrar.Name = "btnAdministrar";
            this.btnAdministrar.Size = new System.Drawing.Size(178, 65);
            this.btnAdministrar.TabIndex = 2;
            this.btnAdministrar.Text = "       Administrar";
            this.btnAdministrar.UseVisualStyleBackColor = false;
            this.btnAdministrar.Click += new System.EventHandler(this.btnAdministrar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Red;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(778, 485);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(117, 45);
            this.btnCerrar.TabIndex = 12;
            this.btnCerrar.Text = "CERRAR SISTEMA";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnListaExcepciones
            // 
            this.btnListaExcepciones.BackColor = System.Drawing.Color.White;
            this.btnListaExcepciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListaExcepciones.Font = new System.Drawing.Font("Britannic Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListaExcepciones.Image = ((System.Drawing.Image)(resources.GetObject("btnListaExcepciones.Image")));
            this.btnListaExcepciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListaExcepciones.Location = new System.Drawing.Point(438, 109);
            this.btnListaExcepciones.Name = "btnListaExcepciones";
            this.btnListaExcepciones.Size = new System.Drawing.Size(202, 65);
            this.btnListaExcepciones.TabIndex = 13;
            this.btnListaExcepciones.Text = "               Excepciones de ingreso";
            this.btnListaExcepciones.UseVisualStyleBackColor = false;
            this.btnListaExcepciones.Click += new System.EventHandler(this.btnListaExcepciones_Click);
            // 
            // btn_Consultas
            // 
            this.btn_Consultas.BackColor = System.Drawing.Color.White;
            this.btn_Consultas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Consultas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Consultas.Image = ((System.Drawing.Image)(resources.GetObject("btn_Consultas.Image")));
            this.btn_Consultas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Consultas.Location = new System.Drawing.Point(646, 109);
            this.btn_Consultas.Name = "btn_Consultas";
            this.btn_Consultas.Size = new System.Drawing.Size(202, 65);
            this.btn_Consultas.TabIndex = 14;
            this.btn_Consultas.Text = "Consultas";
            this.btn_Consultas.UseVisualStyleBackColor = false;
            this.btn_Consultas.Click += new System.EventHandler(this.btn_Consultas_Click);
            // 
            // btnEgresoCiudadano
            // 
            this.btnEgresoCiudadano.BackColor = System.Drawing.Color.White;
            this.btnEgresoCiudadano.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEgresoCiudadano.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEgresoCiudadano.Image = ((System.Drawing.Image)(resources.GetObject("btnEgresoCiudadano.Image")));
            this.btnEgresoCiudadano.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEgresoCiudadano.Location = new System.Drawing.Point(70, 192);
            this.btnEgresoCiudadano.Name = "btnEgresoCiudadano";
            this.btnEgresoCiudadano.Size = new System.Drawing.Size(178, 65);
            this.btnEgresoCiudadano.TabIndex = 15;
            this.btnEgresoCiudadano.Text = "Reg. Salida";
            this.btnEgresoCiudadano.UseVisualStyleBackColor = false;
            this.btnEgresoCiudadano.Click += new System.EventHandler(this.btnEgresoCiudadano_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 542);
            this.Controls.Add(this.btnEgresoCiudadano);
            this.Controls.Add(this.btn_Consultas);
            this.Controls.Add(this.btnListaExcepciones);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnRegistroDiario);
            this.Controls.Add(this.btnAdministrar);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPrincipal";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdministrar;
        private System.Windows.Forms.Button btnRegistroDiario;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnListaExcepciones;
        private System.Windows.Forms.Button btn_Consultas;
        private System.Windows.Forms.Button btnEgresoCiudadano;
    }
}
namespace CapaPresentacion
{
    partial class frmInternosBuscar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInternosBuscar));
            this.btnBuscarApellido = new System.Windows.Forms.Button();
            this.dtvInternos = new System.Windows.Forms.DataGridView();
            this.txtBuscarApellidoInternos = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtvInternos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscarApellido
            // 
            this.btnBuscarApellido.BackColor = System.Drawing.Color.White;
            this.btnBuscarApellido.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscarApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarApellido.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarApellido.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarApellido.Image")));
            this.btnBuscarApellido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarApellido.Location = new System.Drawing.Point(332, 45);
            this.btnBuscarApellido.Name = "btnBuscarApellido";
            this.btnBuscarApellido.Size = new System.Drawing.Size(165, 32);
            this.btnBuscarApellido.TabIndex = 77;
            this.btnBuscarApellido.Text = "BUSCAR";
            this.btnBuscarApellido.UseVisualStyleBackColor = false;
            this.btnBuscarApellido.Click += new System.EventHandler(this.btnBuscarApellido_Click);
            // 
            // dtvInternos
            // 
            this.dtvInternos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtvInternos.Location = new System.Drawing.Point(14, 95);
            this.dtvInternos.Name = "dtvInternos";
            this.dtvInternos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtvInternos.Size = new System.Drawing.Size(677, 345);
            this.dtvInternos.TabIndex = 78;
            this.dtvInternos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtvInternos_KeyDown);
            // 
            // txtBuscarApellidoInternos
            // 
            this.txtBuscarApellidoInternos.Location = new System.Drawing.Point(91, 51);
            this.txtBuscarApellidoInternos.Name = "txtBuscarApellidoInternos";
            this.txtBuscarApellidoInternos.Size = new System.Drawing.Size(216, 20);
            this.txtBuscarApellidoInternos.TabIndex = 76;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Maroon;
            this.label23.Location = new System.Drawing.Point(86, 9);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(177, 25);
            this.label23.TabIndex = 107;
            this.label23.Text = "Buscar Internos";
            // 
            // frmInternosBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.btnBuscarApellido);
            this.Controls.Add(this.dtvInternos);
            this.Controls.Add(this.txtBuscarApellidoInternos);
            this.Name = "frmInternosBuscar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmInternosBuscar";
            ((System.ComponentModel.ISupportInitialize)(this.dtvInternos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscarApellido;
        private System.Windows.Forms.DataGridView dtvInternos;
        private System.Windows.Forms.TextBox txtBuscarApellidoInternos;
        private System.Windows.Forms.Label label23;
    }
}
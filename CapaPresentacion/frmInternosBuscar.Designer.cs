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
            this.btnBuscarApellido = new System.Windows.Forms.Button();
            this.dtvInternos = new System.Windows.Forms.DataGridView();
            this.txtBuscarApellidoInternos = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtvInternos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscarApellido
            // 
            this.btnBuscarApellido.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnBuscarApellido.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscarApellido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarApellido.ForeColor = System.Drawing.Color.White;
            this.btnBuscarApellido.Location = new System.Drawing.Point(317, 39);
            this.btnBuscarApellido.Name = "btnBuscarApellido";
            this.btnBuscarApellido.Size = new System.Drawing.Size(80, 45);
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
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Blue;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(1, 1);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(700, 29);
            this.label28.TabIndex = 79;
            this.label28.Text = "BUSCAR INTERNO";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmInternosBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBuscarApellido);
            this.Controls.Add(this.dtvInternos);
            this.Controls.Add(this.txtBuscarApellidoInternos);
            this.Controls.Add(this.label28);
            this.Name = "frmInternosBuscar";
            this.Text = "frmInternosBuscar";
            ((System.ComponentModel.ISupportInitialize)(this.dtvInternos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscarApellido;
        private System.Windows.Forms.DataGridView dtvInternos;
        private System.Windows.Forms.TextBox txtBuscarApellidoInternos;
        private System.Windows.Forms.Label label28;
    }
}
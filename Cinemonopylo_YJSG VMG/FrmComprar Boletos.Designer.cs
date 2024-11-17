namespace Cinemonopylo_YJSG_VMG
{
    partial class FrmComprar_Boletos
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbPeliculas = new System.Windows.Forms.ComboBox();
            this.cmbHorarios = new System.Windows.Forms.ComboBox();
            this.pnlAsientos = new System.Windows.Forms.Panel();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.pnlResumen = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = global::Cinemonopylo_YJSG_VMG.Properties.Resources._9;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.ForeColor = System.Drawing.Color.Transparent;
            this.btnCancelar.Location = new System.Drawing.Point(1987, 0);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(114, 106);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cmbPeliculas
            // 
            this.cmbPeliculas.FormattingEnabled = true;
            this.cmbPeliculas.Location = new System.Drawing.Point(112, 131);
            this.cmbPeliculas.Name = "cmbPeliculas";
            this.cmbPeliculas.Size = new System.Drawing.Size(499, 64);
            this.cmbPeliculas.TabIndex = 1;
            // 
            // cmbHorarios
            // 
            this.cmbHorarios.FormattingEnabled = true;
            this.cmbHorarios.Location = new System.Drawing.Point(112, 296);
            this.cmbHorarios.Name = "cmbHorarios";
            this.cmbHorarios.Size = new System.Drawing.Size(499, 64);
            this.cmbHorarios.TabIndex = 2;
            // 
            // pnlAsientos
            // 
            this.pnlAsientos.Location = new System.Drawing.Point(117, 462);
            this.pnlAsientos.Name = "pnlAsientos";
            this.pnlAsientos.Size = new System.Drawing.Size(1146, 1022);
            this.pnlAsientos.TabIndex = 3;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnConfirmar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConfirmar.Location = new System.Drawing.Point(1423, 969);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(423, 95);
            this.btnConfirmar.TabIndex = 5;
            this.btnConfirmar.Text = "CONFIRMAR COMPRA";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            // 
            // pnlResumen
            // 
            this.pnlResumen.Location = new System.Drawing.Point(1336, 402);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Size = new System.Drawing.Size(598, 482);
            this.pnlResumen.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 56);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione una película:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(338, 56);
            this.label2.TabIndex = 7;
            this.label2.Text = "Seleccione un horario:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 386);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(358, 56);
            this.label3.TabIndex = 8;
            this.label3.Text = "Seleccione los asientos:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(1503, 1559);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(598, 67);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(1337, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(597, 302);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Por favor, ingrese metodo de pago:";
            // 
            // FrmComprar_Boletos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(2100, 1628);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlResumen);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.pnlAsientos);
            this.Controls.Add(this.cmbHorarios);
            this.Controls.Add(this.cmbPeliculas);
            this.Controls.Add(this.btnCancelar);
            this.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(2100, 1920);
            this.MinimumSize = new System.Drawing.Size(1920, 1200);
            this.Name = "FrmComprar_Boletos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmComprar_Boletos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cmbPeliculas;
        private System.Windows.Forms.ComboBox cmbHorarios;
        private System.Windows.Forms.Panel pnlAsientos;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.FlowLayoutPanel pnlResumen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
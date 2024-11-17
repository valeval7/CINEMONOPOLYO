namespace Cinemonopylo_YJSG_VMG
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnClientes = new System.Windows.Forms.ToolStripButton();
            this.btnTaquilla = new System.Windows.Forms.ToolStripButton();
            this.btnAdministrar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.lblInfo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(471, 0);
            this.groupBox1.MaximumSize = new System.Drawing.Size(2100, 1800);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1937, 1400);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(194, 1300);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(1578, 50);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 332);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2162, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "↩︎ SELECCIONE UNA OPCIÓN:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Cinemonopylo_YJSG_VMG.Properties.Resources.TBD_PROYECTO_FINAL_YJGSVMG;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(-500, 29);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(3200, 3200);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2500, 1400);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(300, 100);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClientes,
            this.btnTaquilla,
            this.btnAdministrar,
            this.toolStripLabel1,
            this.btnSalir});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(471, 1400);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnClientes
            // 
            this.btnClientes.AutoSize = false;
            this.btnClientes.BackColor = System.Drawing.Color.Transparent;
            this.btnClientes.BackgroundImage = global::Cinemonopylo_YJSG_VMG.Properties.Resources._11;
            this.btnClientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClientes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClientes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(170, 170);
            this.btnClientes.Text = "Módulo de CLIENTES";
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnTaquilla
            // 
            this.btnTaquilla.AutoSize = false;
            this.btnTaquilla.BackgroundImage = global::Cinemonopylo_YJSG_VMG.Properties.Resources._2;
            this.btnTaquilla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTaquilla.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTaquilla.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTaquilla.Name = "btnTaquilla";
            this.btnTaquilla.Size = new System.Drawing.Size(170, 170);
            this.btnTaquilla.Text = "Módulo de TAQUILLA";
            // 
            // btnAdministrar
            // 
            this.btnAdministrar.AutoSize = false;
            this.btnAdministrar.BackgroundImage = global::Cinemonopylo_YJSG_VMG.Properties.Resources._3;
            this.btnAdministrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdministrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdministrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdministrar.Name = "btnAdministrar";
            this.btnAdministrar.Size = new System.Drawing.Size(170, 170);
            this.btnAdministrar.Text = "Módulo para ADMINISTRAR";
            // 
            // btnSalir
            // 
            this.btnSalir.AutoSize = false;
            this.btnSalir.BackgroundImage = global::Cinemonopylo_YJSG_VMG.Properties.Resources._4;
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(150, 150);
            this.btnSalir.Text = "ABANDONAR";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(2408, 1400);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MaximumSize = new System.Drawing.Size(3200, 3200);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripButton btnClientes;
        private System.Windows.Forms.ToolStripButton btnTaquilla;
        private System.Windows.Forms.ToolStripButton btnAdministrar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.ToolStrip toolStrip1;
    }
}


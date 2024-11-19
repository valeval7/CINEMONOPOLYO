namespace Cinemonopylo_YJSG_VMG
{
    partial class FrmMenuAdministrador
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.txtInfo = new System.Windows.Forms.ToolStripTextBox();
            this.btnPeliculas = new System.Windows.Forms.ToolStripButton();
            this.btnSalas = new System.Windows.Forms.ToolStripButton();
            this.btnUsuarios = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtInfo,
            this.btnPeliculas,
            this.btnSalas,
            this.btnUsuarios,
            this.toolStripLabel1,
            this.btnSalir});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(302, 1500);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // txtInfo
            // 
            this.txtInfo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(293, 39);
            // 
            // btnPeliculas
            // 
            this.btnPeliculas.AutoSize = false;
            this.btnPeliculas.BackColor = System.Drawing.Color.Transparent;
            this.btnPeliculas.BackgroundImage = global::Cinemonopylo_YJSG_VMG.Properties.Resources._7;
            this.btnPeliculas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPeliculas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPeliculas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPeliculas.Name = "btnPeliculas";
            this.btnPeliculas.Size = new System.Drawing.Size(250, 120);
            this.btnPeliculas.Click += new System.EventHandler(this.btnPeliculas_Click);
            // 
            // btnSalas
            // 
            this.btnSalas.AutoSize = false;
            this.btnSalas.BackgroundImage = global::Cinemonopylo_YJSG_VMG.Properties.Resources._8;
            this.btnSalas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSalas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSalas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalas.Name = "btnSalas";
            this.btnSalas.Size = new System.Drawing.Size(250, 120);
            this.btnSalas.Click += new System.EventHandler(this.btnSalas_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.AutoSize = false;
            this.btnUsuarios.BackgroundImage = global::Cinemonopylo_YJSG_VMG.Properties.Resources._6;
            this.btnUsuarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUsuarios.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUsuarios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(250, 120);
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(300, 200);
            // 
            // btnSalir
            // 
            this.btnSalir.AutoSize = false;
            this.btnSalir.BackgroundImage = global::Cinemonopylo_YJSG_VMG.Properties.Resources.regresar;
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 100);
            this.btnSalir.Text = "CERRAR SESIÓN";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmMenuAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(2408, 1500);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Location = new System.Drawing.Point(310, 100);
            this.MaximumSize = new System.Drawing.Size(3200, 3200);
            this.MinimumSize = new System.Drawing.Size(2408, 1400);
            this.Name = "FrmMenuAdministrador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmMenuAdministrador";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox txtInfo;
        private System.Windows.Forms.ToolStripButton btnPeliculas;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.ToolStripButton btnUsuarios;
        private System.Windows.Forms.ToolStripButton btnSalas;
    }
}
namespace Presentacion_TallerAutomotiz
{
    partial class FrmLogin
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
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnInvitado = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(56, 159);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(525, 46);
            this.txtUsuario.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16.125F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(74)))), ((int)(((byte)(107)))));
            this.label1.Location = new System.Drawing.Point(46, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 16.125F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(74)))), ((int)(((byte)(107)))));
            this.label2.Location = new System.Drawing.Point(46, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 59);
            this.label2.TabIndex = 0;
            this.label2.Text = "Contraseña:";
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(56, 323);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(525, 46);
            this.txtClave.TabIndex = 2;
            this.txtClave.UseSystemPasswordChar = true;
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(142)))), ((int)(((byte)(118)))));
            this.btnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnIniciar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnIniciar.Location = new System.Drawing.Point(61, 421);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(520, 63);
            this.btnIniciar.TabIndex = 3;
            this.btnIniciar.Text = "INICIAR SESIÓN";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("PMingLiU-ExtB", 19.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(74)))), ((int)(((byte)(107)))));
            this.label3.Location = new System.Drawing.Point(854, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(525, 59);
            this.label3.TabIndex = 0;
            this.label3.Text = "Acceso al sistema!";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::Cinemonopylo_YJSG_VMG.Properties.Resources._91;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(1408, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 75);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnIniciar);
            this.groupBox1.Controls.Add(this.txtClave);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Font = new System.Drawing.Font("PMingLiU-ExtB", 12F);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(74)))), ((int)(((byte)(107)))));
            this.groupBox1.Location = new System.Drawing.Point(813, 372);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(664, 540);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Iniciar sesión:";
            // 
            // btnInvitado
            // 
            this.btnInvitado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(142)))), ((int)(((byte)(118)))));
            this.btnInvitado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvitado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnInvitado.ForeColor = System.Drawing.SystemColors.Control;
            this.btnInvitado.Location = new System.Drawing.Point(72, 45);
            this.btnInvitado.Name = "btnInvitado";
            this.btnInvitado.Size = new System.Drawing.Size(520, 63);
            this.btnInvitado.TabIndex = 4;
            this.btnInvitado.Text = "INVITADO";
            this.btnInvitado.UseVisualStyleBackColor = false;
            this.btnInvitado.Click += new System.EventHandler(this.btnInvitado_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnInvitado);
            this.groupBox2.Font = new System.Drawing.Font("PMingLiU-ExtB", 12F);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(74)))), ((int)(((byte)(107)))));
            this.groupBox2.Location = new System.Drawing.Point(813, 194);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(663, 150);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ingresar como invitado:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("PMingLiU-ExtB", 12F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(74)))), ((int)(((byte)(107)))));
            this.label4.Location = new System.Drawing.Point(892, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(450, 32);
            this.label4.TabIndex = 8;
            this.label4.Text = "Por favor, seleccione su preferencia:";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::Cinemonopylo_YJSG_VMG.Properties.Resources._24;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1490, 924);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1200);
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "`";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnInvitado;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
    }
}
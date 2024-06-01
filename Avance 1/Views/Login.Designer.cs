
namespace Avance_1
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.lblNuevaCuenta = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSalir = new FontAwesome.Sharp.IconButton();
            this.btnIngresar = new FontAwesome.Sharp.IconButton();
            this.lblIngreso = new System.Windows.Forms.Label();
            this.lblSaludo = new System.Windows.Forms.Label();
            this.pnlCredenciales = new System.Windows.Forms.Panel();
            this.chkMostrar = new System.Windows.Forms.CheckBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.ptbPassword = new FontAwesome.Sharp.IconPictureBox();
            this.ptbUser = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlCredenciales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbUser)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Snow;
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.DarkBlue;
            this.splitContainer1.Panel1.Controls.Add(this.btnRegistrar);
            this.splitContainer1.Panel1.Controls.Add(this.lblNuevaCuenta);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSalir);
            this.splitContainer1.Panel2.Controls.Add(this.btnIngresar);
            this.splitContainer1.Panel2.Controls.Add(this.lblIngreso);
            this.splitContainer1.Panel2.Controls.Add(this.lblSaludo);
            this.splitContainer1.Panel2.Controls.Add(this.pnlCredenciales);
            // 
            // btnRegistrar
            // 
            resources.ApplyResources(this.btnRegistrar, "btnRegistrar");
            this.btnRegistrar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // lblNuevaCuenta
            // 
            resources.ApplyResources(this.lblNuevaCuenta, "lblNuevaCuenta");
            this.lblNuevaCuenta.ForeColor = System.Drawing.SystemColors.Control;
            this.lblNuevaCuenta.Name = "lblNuevaCuenta";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkBlue;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Red;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnSalir, "btnSalir");
            this.btnSalir.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSalir.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btnSalir.IconColor = System.Drawing.SystemColors.Control;
            this.btnSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSalir.IconSize = 20;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.DarkBlue;
            this.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresar.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnIngresar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnIngresar.IconColor = System.Drawing.Color.AliceBlue;
            this.btnIngresar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            resources.ApplyResources(this.btnIngresar, "btnIngresar");
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // lblIngreso
            // 
            resources.ApplyResources(this.lblIngreso, "lblIngreso");
            this.lblIngreso.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblIngreso.Name = "lblIngreso";
            // 
            // lblSaludo
            // 
            resources.ApplyResources(this.lblSaludo, "lblSaludo");
            this.lblSaludo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSaludo.Name = "lblSaludo";
            // 
            // pnlCredenciales
            // 
            this.pnlCredenciales.Controls.Add(this.chkMostrar);
            this.pnlCredenciales.Controls.Add(this.txtPass);
            this.pnlCredenciales.Controls.Add(this.txtUser);
            this.pnlCredenciales.Controls.Add(this.ptbPassword);
            this.pnlCredenciales.Controls.Add(this.ptbUser);
            resources.ApplyResources(this.pnlCredenciales, "pnlCredenciales");
            this.pnlCredenciales.Name = "pnlCredenciales";
            // 
            // chkMostrar
            // 
            resources.ApplyResources(this.chkMostrar, "chkMostrar");
            this.chkMostrar.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkMostrar.Name = "chkMostrar";
            this.chkMostrar.UseVisualStyleBackColor = true;
            this.chkMostrar.CheckedChanged += new System.EventHandler(this.chkMostrar_CheckedChanged);
            // 
            // txtPass
            // 
            resources.ApplyResources(this.txtPass, "txtPass");
            this.txtPass.Name = "txtPass";
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // txtUser
            // 
            resources.ApplyResources(this.txtUser, "txtUser");
            this.txtUser.Name = "txtUser";
            // 
            // ptbPassword
            // 
            this.ptbPassword.BackColor = System.Drawing.Color.Snow;
            this.ptbPassword.ForeColor = System.Drawing.Color.DarkBlue;
            this.ptbPassword.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.ptbPassword.IconColor = System.Drawing.Color.DarkBlue;
            this.ptbPassword.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ptbPassword.IconSize = 30;
            resources.ApplyResources(this.ptbPassword, "ptbPassword");
            this.ptbPassword.Name = "ptbPassword";
            this.ptbPassword.TabStop = false;
            // 
            // ptbUser
            // 
            this.ptbUser.BackColor = System.Drawing.Color.Snow;
            this.ptbUser.ForeColor = System.Drawing.Color.DarkBlue;
            this.ptbUser.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.ptbUser.IconColor = System.Drawing.Color.DarkBlue;
            this.ptbUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ptbUser.IconSize = 30;
            resources.ApplyResources(this.ptbUser, "ptbUser");
            this.ptbUser.Name = "ptbUser";
            this.ptbUser.TabStop = false;
            // 
            // Login
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Shown += new System.EventHandler(this.Login_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlCredenciales.ResumeLayout(false);
            this.pnlCredenciales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label lblNuevaCuenta;
        private System.Windows.Forms.Label lblIngreso;
        private System.Windows.Forms.Label lblSaludo;
        private FontAwesome.Sharp.IconButton btnIngresar;
        private FontAwesome.Sharp.IconButton btnSalir;
        private System.Windows.Forms.Panel pnlCredenciales;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUser;
        private FontAwesome.Sharp.IconPictureBox ptbPassword;
        private FontAwesome.Sharp.IconPictureBox ptbUser;
        private System.Windows.Forms.CheckBox chkMostrar;
    }
}



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
            this.label1 = new System.Windows.Forms.Label();
            this.Usuario = new System.Windows.Forms.Label();
            this.txt_Usuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Contra = new System.Windows.Forms.TextBox();
            this.btn_Acceso = new System.Windows.Forms.Button();
            this.btn_Salir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Usuario
            // 
            resources.ApplyResources(this.Usuario, "Usuario");
            this.Usuario.Name = "Usuario";
            // 
            // txt_Usuario
            // 
            resources.ApplyResources(this.txt_Usuario, "txt_Usuario");
            this.txt_Usuario.Name = "txt_Usuario";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txt_Contra
            // 
            resources.ApplyResources(this.txt_Contra, "txt_Contra");
            this.txt_Contra.Name = "txt_Contra";
            this.txt_Contra.UseSystemPasswordChar = true;
            // 
            // btn_Acceso
            // 
            resources.ApplyResources(this.btn_Acceso, "btn_Acceso");
            this.btn_Acceso.Name = "btn_Acceso";
            this.btn_Acceso.UseVisualStyleBackColor = true;
            this.btn_Acceso.Click += new System.EventHandler(this.btn_Acceso_Click);
            // 
            // btn_Salir
            // 
            resources.ApplyResources(this.btn_Salir, "btn_Salir");
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.UseVisualStyleBackColor = true;
            this.btn_Salir.Click += new System.EventHandler(this.btn_Salir_Click);
            // 
            // Login
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Salir);
            this.Controls.Add(this.btn_Acceso);
            this.Controls.Add(this.txt_Contra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Usuario);
            this.Controls.Add(this.Usuario);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Usuario;
        private System.Windows.Forms.TextBox txt_Usuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Contra;
        private System.Windows.Forms.Button btn_Acceso;
        private System.Windows.Forms.Button btn_Salir;
    }
}


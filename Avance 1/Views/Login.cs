using Avance_1.Data;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Avance_1
{
    public partial class Login : Form
    {
        private AutenticarLogin auth;

        public Login()
        {
            InitializeComponent();
            auth = new AutenticarLogin();
            this.ControlBox = false;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUser.Text.Trim();
            string contraseña = txtPass.Text.Trim();

            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor ingrese nombre de usuario y contraseña", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (auth.Authenticate(nombreUsuario, contraseña))
                {
                    MessageBox.Show("Inicio de sesión exitoso. ¡Bienvenido!", "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUser.Clear();
                    txtPass.Clear();
                    Dashboard sistemaForm2 = new Dashboard();
                    sistemaForm2.FormClosed += (s, arg) => this.Close();
                    sistemaForm2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas. Por favor, inténtelo de nuevo.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUser.Clear();
                    txtPass.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectarse a la base de datos: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !chkMostrar.Checked;
        }


        private void Login_Shown(object sender, EventArgs e)
        {
            txtUser.Focus();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Nueva_Cuenta nueva = new Nueva_Cuenta();
            nueva.Show();
            this.Hide();
        } 
    }
}

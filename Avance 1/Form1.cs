using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avance_1
{
    public partial class Login : Form
    {
        private ConexionBD mConexion;

        public Login()
        {
            InitializeComponent();
            mConexion = new ConexionBD();
        }

        private void btn_Acceso_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txt_Usuario.Text;
            string contraseña = txt_Contra.Text;

            string consulta = "SELECT * FROM usuario WHERE nombre_usuario = @nombre_usuario AND pass = @pass";

            using (MySqlConnection conexion = mConexion.GetConexion())
            {
                conexion.Open();
                if (conexion != null)
                {
                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@nombre_usuario", nombreUsuario);
                        comando.Parameters.AddWithValue("@pass", contraseña);

                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                MessageBox.Show("Inicio de sesión exitoso");
                                Form2 SistemaForm2 = new Form2();
                                SistemaForm2.FormClosed += (s, arg) => this.Close();
                                SistemaForm2.Show();
                                this.Hide();
                                conexion.Close();
                                // Aquí puedes agregar el código para abrir el formulario principal
                            }
                            else
                            {
                                MessageBox.Show("Credenciales incorrectas");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error al conectarse a la base de datos");
                }
            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
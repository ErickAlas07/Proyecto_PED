using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using FluentValidation;
namespace Avance_1
{
    public partial class Form3 : Form
    {
        private ConexionBD mConexion;
       public Form3()
        {
            InitializeComponent();
            this.FormClosed += Form3_FormClosed;
            mConexion = new ConexionBD();
        }
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Se cierra la aplicación al cerrar el formulario//
            Application.Exit();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            //CargarDatos();

        }

        private void CargarDatos()
        {
            using (MySqlConnection conexion = mConexion.GetConexion())
            {
                if (conexion != null)
                {
                    string consulta = "SELECT * FROM materia";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    dataGridView1.DataSource = tabla;
                    
                }
                else
                {
                    MessageBox.Show("Error al conectarse a la base de datos");
                }
            }
        }
        private void btn_Agregar_Click(object sender, EventArgs e)
        {

            string nom_Materia = txt_materia.Text;
            string descripcion = txt_Descrip.Text;
            string aula = txt_Aula.Text;
            string facultad = txt_Facultad.Text;
            string abreviatura = txt_abrev.Text;
            int docente = Int32.Parse(txt_Docente.Text);

            string consulta = "INSERT INTO materia(nombre, descripcion, aula, escuela, abreviatura, id_profesor) " +
                              $"VALUES ('{nom_Materia}', '{descripcion}', '{aula}', '{facultad}', '{abreviatura}', {docente});";
           
            try
           {
                using (MySqlConnection conexion = mConexion.GetConexion())
                {
                    conexion.Open();
                    if (conexion!=null)
                    {
                        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                        {
                            comando.ExecuteNonQuery();
                            MessageBox.Show("Registro agregado correctamente");
                            CargarDatos(); // Actualiza el DataGridView con los nuevos datos
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al conectarse a la base de datos");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el registro: " + ex.Message);
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}


using Avance_1.Data;
using Avance_1.Models;
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
    public partial class Nueva_Cuenta : Form
    {
        private ConexionBD conexionBD = new ConexionBD();
        private bool IsUserLoggedIn { get; set; } = true; 
        private bool IsUserAdmin { get; set; } = true; 

        public Nueva_Cuenta()
        {
            InitializeComponent();
            cmbRoles.SelectedIndexChanged += cmbRoles_SelectedIndexChanged;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            // Validación en caso que el combobox esté vacío 
            if (cmbRoles.SelectedItem == null)
            {
                MessageBox.Show("Por favor seleccione un rol.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Almacenar dentro de la variable la cadena del combobox
            string role = cmbRoles.SelectedItem.ToString();

            // Validación en caso que el combobox tenga seleccionado el administrador
            if (role == "Administrador" && (!IsUserLoggedIn || !IsUserAdmin))
            {
                MessageBox.Show("Solo los administradores pueden crear cuentas de administrador.");
                return;
            }

            // Variables para almacenar datos del formulario
            string nombre = txtNombres.Text;
            string apellido = txtApellidos.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            bool isValid = false;
            string errorMessage = "";

            Usuario nuevo = null;

            if (role == "Estudiante")
            {
                nuevo = new Estudiante(
                    username, password, GetRoleId(role), GenerateStudentId(nombre, apellido),
                    nombre, apellido, dtpBirthdate.Value,
                    cmbGenero.SelectedItem.ToString(), txtDireccion.Text, txtContacto.Text, txtCorreo.Text);
            }
            else if (role == "Profesor")
            {
                nuevo = new Profesor(
                    username, password, GetRoleId(role),
                    nombre, apellido, txtTitulo.Text);
            }
            else if (role == "Administrador")
            {
                nuevo = new Usuario(username, password, GetRoleId(role));
            }

            if (nuevo != null)
            {
                isValid = nuevo.Validate(out errorMessage);
            }

            if (!isValid)
            {
                MessageBox.Show(errorMessage, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (nuevo is Estudiante estudiante)
                {
                    var estudianteDataAccess = new EstudianteDataAccess();
                    estudianteDataAccess.InsertarEstudiante(estudiante);
                }
                else if (nuevo is Profesor profesor)
                {
                    var profesorDataAccess = new ProfesorDataAccess();
                    profesorDataAccess.InsertarProfesor(profesor);
                }
                else
                {
                    var usuarioDataAccess = new UsuarioDataAccess();
                    usuarioDataAccess.InsertarUsuario(nuevo);
                }

                MessageBox.Show("Cuenta creada exitosamente.");
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la cuenta: " + ex.Message);
            }
        }

        private void Nueva_Cuenta_Load(object sender, EventArgs e)
        {
            // Inicializar el ComboBox con las opciones de rol
            cmbRoles.Items.Add("Administrador");
            cmbRoles.Items.Add("Profesor");
            cmbRoles.Items.Add("Estudiante");

            // Inicializar el ComboBox de género
            cmbGenero.Items.Add("F");
            cmbGenero.Items.Add("M");
            cmbGenero.SelectedIndex = 0;
        }

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rol = cmbRoles.SelectedItem.ToString();
            switch (rol)
            {
                case "Administrador":
                    SetVisibility(false, false);
                    break;
                case "Profesor":
                    SetVisibility(false, true);
                    break;
                case "Estudiante":
                    SetVisibility(true, false);
                    break;
            }
        }

        private void limpiar()
        {
            txtNombres.Clear();
            txtApellidos.Clear();
            txtDireccion.Clear();
            txtContacto.Clear();
            txtCorreo.Clear();
            txtTitulo.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            cmbGenero.SelectedIndex = 0;
            cmbRoles.SelectedIndex = 0;
        }

        private void SetVisibility(bool isStudent, bool isTeacher)
        {
            // Controles comunes
            txtUsername.Visible = true;
            txtPassword.Visible = true;

            // Controles específicos
            dtpBirthdate.Visible = isStudent;
            lblFechaNac.Visible = isStudent;
            cmbGenero.Visible = isStudent;
            lblGenero.Visible = isStudent;
            txtDireccion.Visible = isStudent;
            lblDireccion.Visible = isStudent;
            txtContacto.Visible = isStudent;
            lblContacto.Visible = isStudent;
            txtCorreo.Visible = isStudent;
            lblEmail.Visible = isStudent;

            txtTitulo.Visible = isTeacher;
            lblTitulo.Visible = isTeacher;

        }

        private int GetRoleId(string role)
        {
            switch (role)
            {
                case "Administrador":
                    return 1;
                case "Profesor":
                    return 2;
                case "Estudiante":
                    return 3;
                default:
                    throw new Exception("Rol desconocido");
            }
        }

        private string GenerateStudentId(string nombre, string apellido)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
            {
                //throw new ArgumentException("El nombre y el apellido no pueden estar vacíos.");
                //MessageBox.Show("Los campos nombre y apellido no pueden estar vacíos", "Campos vacíos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            string year = DateTime.Now.Year.ToString().Substring(2, 2);
            Random rnd = new Random();
            string randomDigits = rnd.Next(1000, 9999).ToString();
            return nombre[0].ToString().ToUpper() + apellido[0].ToString().ToUpper() + year + randomDigits;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

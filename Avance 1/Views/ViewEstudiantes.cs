using Avance_1.Data;
using Avance_1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avance_1.Views
{
    public partial class ViewEstudiantes : UserControl
    {
        EstudianteDataAccess edataAccess; 

        public ViewEstudiantes()
        {
            InitializeComponent();
            edataAccess = new EstudianteDataAccess();
            CargarDatos();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // Inicializa el ComboBox de género
            cmbGenero.Items.Add("F");
            cmbGenero.Items.Add("M");
            cmbGenero.SelectedIndex = 0;
        }

        private void CargarDatos()
        {
            try
            {
                DataTable tabla = edataAccess.TodosEstudiantes();
                dataGridView1.DataSource = tabla;

                // Desactiva la selección de filas por defecto
                dataGridView1.ClearSelection();
                dataGridView1.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }
        }

        // Método para limpiar campos de formulario
        private void limpiar()
        {
            txtNombreEst.Clear();
            txtApellidoEst.Clear();
            txtDireccion.Clear();
            txtContacto.Clear();
            txtCorreo.Clear();
            cmbGenero.SelectedIndex = 0;
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombreEst.Text) ||
                string.IsNullOrWhiteSpace(txtApellidoEst.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) || 
                string.IsNullOrWhiteSpace(txtContacto.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de continuar.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                limpiar();
                dataGridView1.ClearSelection();
                dataGridView1.CurrentCell = null;
                return false;
            }
            return true;
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

        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreEst.Text;
            string apellido = txtApellidoEst.Text;
            string direccion = txtDireccion.Text;
            string contacto = txtContacto.Text;
            string email = txtCorreo.Text;
            string genero = cmbGenero.SelectedItem.ToString();
            string id = dataGridView1.SelectedRows[0].Cells["Carnet"].Value.ToString();

            // Validar entradas
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(direccion) 
                || string.IsNullOrWhiteSpace(contacto) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(genero))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
       
            Estudiante nuevoEstudiante = new Estudiante(null, "1234", 3, GenerateStudentId(nombre, apellido), nombre, apellido, dtpBirthdate.Value, genero, direccion, contacto, email);

            try
            {
                edataAccess.NuevoEstudiante(nuevoEstudiante);
                MessageBox.Show("Estudiante agregado correctamente.");
                CargarDatos(); // Actualiza el DataGridView con los nuevos datos
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el estudiante: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells["Carnet"].Value.ToString();
            
            if (ValidarCampos())
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    
                    Estudiante estudianteModificado = new Estudiante(null, null, 0, null, txtNombreEst.Text, txtApellidoEst.Text, dtpBirthdate.Value, cmbGenero.SelectedItem.ToString(), txtDireccion.Text, txtContacto.Text, txtCorreo.Text)
                    {
                        IdEstudiante = id
                    };

                    try
                    {
                        edataAccess.AcualizarEstudiante(estudianteModificado);
                        MessageBox.Show("Registro modificado correctamente");
                        CargarDatos(); // Actualiza el DataGridView con los nuevos datos
                        limpiar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al modificar el registro: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una fila para modificar.");
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string nombreCompleto = selectedRow.Cells["Estudiante"].Value.ToString();

                // Encuentra el índice del primer espacio
                int primerEspacio = nombreCompleto.IndexOf(' ');

                if (primerEspacio > -1)
                {
                    // Divide el nombre completo en nombre y apellido
                    txtNombreEst.Text = nombreCompleto.Substring(0, primerEspacio);
                    txtApellidoEst.Text = nombreCompleto.Substring(primerEspacio + 1);
                }
                else
                {
                    // Si no hay espacio, asume que todo es el nombre
                    txtNombreEst.Text = nombreCompleto;
                    txtApellidoEst.Text = string.Empty;
                }

                txtDireccion.Text = selectedRow.Cells["dirección"].Value.ToString();
                txtContacto.Text = selectedRow.Cells["teléfono"].Value.ToString();
                txtCorreo.Text = selectedRow.Cells["correo_electrónico"].Value.ToString();
                cmbGenero.SelectedItem = selectedRow.Cells["género"].Value.ToString();
                dtpBirthdate.Text = selectedRow.Cells["fecha_de_nacimiento"].Value.ToString();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string id = dataGridView1.SelectedRows[0].Cells["Carnet"].Value.ToString();

                try
                {
                    edataAccess.EliminarEstudiante(id);
                    MessageBox.Show("Estudiante eliminado correctamente");
                    CargarDatos(); // Actualiza el DataGridView con los nuevos datos
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el estudiante: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.");
            }
        }

        private void ViewEstudiantes_Load(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}

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
    public partial class ViewProfesores : UserControl
    {
        private ProfesorDataAccess pdataAccess;
        public ViewProfesores()
        {
            InitializeComponent();
            pdataAccess = new ProfesorDataAccess();
            CargarDatos();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private void CargarDatos()
        {
            try
            {
                DataTable tabla = pdataAccess.TodosProfesores();
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
            txtNombreProf.Text = string.Empty;
            txtApellidoProf.Text = string.Empty;
            txtTitulo.Text = string.Empty;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombreProf.Text) ||
                string.IsNullOrWhiteSpace(txtApellidoProf.Text) ||
                string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de continuar.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                limpiar();
                dataGridView1.ClearSelection();
                dataGridView1.CurrentCell = null;
                return false;
            }
            return true;
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreProf.Text;
            string apellido = txtApellidoProf.Text;
            string titulo = txtTitulo.Text;

            // Validar entradas
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(titulo))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pdataAccess.ExisteProfesor(nombre, apellido))
            {
                MessageBox.Show("El profesor ya existe.", "Registro Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Profesor nuevoProfesor = new Profesor(null, "1234", 2, nombre, apellido, titulo);

            try
            {
                pdataAccess.NuevoProfesor(nuevoProfesor);
                MessageBox.Show("Profesor agregado correctamente.");
                CargarDatos(); // Actualiza el DataGridView con los nuevos datos
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el profesor: " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DetallesProfesor dp = new DetallesProfesor();
            dp.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (pdataAccess.ExisteProfesor(txtNombreProf.Text, txtApellidoProf.Text))
                {
                    MessageBox.Show("El profesor ya existe.", "Registro Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_profesor"].Value);
                    Profesor profesorModificado = new Profesor(null, null, 0, txtNombreProf.Text, txtApellidoProf.Text, txtTitulo.Text)
                    {
                        Id = id
                    };

                    try
                    {
                        pdataAccess.AcualizarProfesor(profesorModificado);
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
                string nombreCompleto = selectedRow.Cells["Profesor"].Value.ToString();

                // Encuentra el índice del primer espacio
                int primerEspacio = nombreCompleto.IndexOf(' ');

                if (primerEspacio > -1)
                {
                    // Divide el nombre completo en nombre y apellido
                    txtNombreProf.Text = nombreCompleto.Substring(0, primerEspacio);
                    txtApellidoProf.Text = nombreCompleto.Substring(primerEspacio + 1);
                }
                else
                {
                    // Si no hay espacio, asume que todo es el nombre
                    txtNombreProf.Text = nombreCompleto;
                    txtApellidoProf.Text = string.Empty;
                }

                txtTitulo.Text = selectedRow.Cells["titulo"].Value.ToString();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_profesor"].Value);

                try
                {
                    pdataAccess.EliminarProfesor(id);
                    MessageBox.Show("Profesor eliminado correctamente");
                    CargarDatos(); // Actualiza el DataGridView con los nuevos datos
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el profesor: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.");
            }
        }
    }
}

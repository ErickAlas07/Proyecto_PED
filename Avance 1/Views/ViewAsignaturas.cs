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

namespace Avance_1.Views
{
    public partial class ViewAsignaturas : UserControl
    {
        private MateriaDataAccess dataAccess;
        private ProfesorDataAccess profesorDataAccess;

    public ViewAsignaturas()
        {
            InitializeComponent();
            dataAccess = new MateriaDataAccess();
            CargarDatos();
            profesorDataAccess = new ProfesorDataAccess();
            CargarProfesores();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged; // Asocia el evento
        }

        private void CargarDatos()
        {
            try
            {
                DataTable tabla = dataAccess.ObtenerMaterias();
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

        private void CargarProfesores()
        {
            try
            {
                List<Profesor> profesores = profesorDataAccess.ObtenerProfesores();
                cmbProfesores.DataSource = profesores;
                cmbProfesores.DisplayMember = "NombreCompleto";
                cmbProfesores.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los profesores: {ex.Message}");
            }
        }

        private void limpiar()
        {
            txtAsignatura.Clear();
            txtDescripcion.Clear();
            txtAula.Clear();
            txtFacultad.Clear();
            txtAbreviatura.Clear();
            cmbProfesores.SelectedIndex = -1;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtAsignatura.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                string.IsNullOrWhiteSpace(txtAula.Text) ||
                string.IsNullOrWhiteSpace(txtFacultad.Text) ||
                string.IsNullOrWhiteSpace(txtAbreviatura.Text) ||
                cmbProfesores.SelectedIndex == -1)
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
            Materia nuevaMateria = new Materia
            {
                Nombre = txtAsignatura.Text,
                Descripcion = txtDescripcion.Text,
                Aula = txtAula.Text,
                Facultad = txtFacultad.Text,
                Abreviatura = txtAbreviatura.Text,
                IdProfesor = (int)cmbProfesores.SelectedValue
            };

            // Validar entradas
            if (string.IsNullOrWhiteSpace(nuevaMateria.Nombre) || string.IsNullOrWhiteSpace(nuevaMateria.Descripcion) ||
                string.IsNullOrWhiteSpace(nuevaMateria.Aula) || string.IsNullOrWhiteSpace(nuevaMateria.Facultad) ||
                string.IsNullOrWhiteSpace(nuevaMateria.Abreviatura) || nuevaMateria.IdProfesor < 0)
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Console.WriteLine(nuevaMateria);
                dataAccess.AgregarMateria(nuevaMateria);
                MessageBox.Show("Registro agregado correctamente");
                CargarDatos(); // Actualiza el DataGridView con los nuevos datos
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la materia: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_materia"].Value);
                    Materia materiaModificada = new Materia
                    {
                        Id = id,
                        Nombre = txtAsignatura.Text,
                        Descripcion = txtDescripcion.Text,
                        Aula = txtAula.Text,
                        Facultad = txtFacultad.Text,
                        Abreviatura = txtAbreviatura.Text,
                        IdProfesor = Convert.ToInt32(cmbProfesores.SelectedValue)
                    };

                    try
                    {
                        dataAccess.AcualizarMateria(materiaModificada);
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_materia"].Value);

                try
                {
                    dataAccess.EliminarMateria(id);
                    MessageBox.Show("Asignatura eliminada correctamente");
                    CargarDatos(); // Actualiza el DataGridView con los nuevos datos
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la asignatura: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                txtAsignatura.Text = selectedRow.Cells["nombre"].Value.ToString();
                txtDescripcion.Text = selectedRow.Cells["descripcion"].Value.ToString();
                txtAula.Text = selectedRow.Cells["aula"].Value.ToString();
                txtFacultad.Text = selectedRow.Cells["escuela"].Value.ToString();
                txtAbreviatura.Text = selectedRow.Cells["abreviatura"].Value.ToString();
                cmbProfesores.SelectedValue = Convert.ToInt32(selectedRow.Cells["id_profesor"].Value);
            }
        }
    }
}

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
    public partial class ViewAdmin : UserControl
    {
        private UsuarioDataAccess udataAccess;

        public ViewAdmin()
        {
            InitializeComponent();
            udataAccess = new UsuarioDataAccess();
            CargarDatos();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private void CargarDatos()
        {
            try
            {
                DataTable tabla = udataAccess.TodosUsuariosAdministradores();
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
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
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
            string userName = txtUserName.Text;
            string password = txtPassword.Text;

            // Validar entradas
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (udataAccess.UsuarioExiste(userName))
            {
                MessageBox.Show("El administrador ya existe.", "Registro Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario nuevoAdministrador = new Usuario(userName, password, 1); // Rol de administrador es 1

            try
            {
                udataAccess.InsertarUsuario(nuevoAdministrador);
                MessageBox.Show("Administrador agregado correctamente.");
                CargarDatos(); // Actualiza el DataGridView con los nuevos datos
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el administrador: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (udataAccess.UsuarioExiste(txtUserName.Text))
                {
                    MessageBox.Show("El administrador ya existe.", "Registro Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_usuario"].Value);
                    Usuario adminModificado = new Usuario(txtUserName.Text, txtPassword.Text, 1) // Rol de administrador es 1
                    {
                        Id = id
                    };

                    try
                    {
                        udataAccess.ActualizarUsuario(adminModificado);
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
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_usuario"].Value);

                try
                {
                    udataAccess.EliminarUsuario(id);
                    MessageBox.Show("Administrador eliminado correctamente");
                    CargarDatos(); // Actualiza el DataGridView con los nuevos datos
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el administrador: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.");
            }
        }

        private void ViewAdmin_Load(object sender, EventArgs e)
        {
            limpiar();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                txtUserName.Text = selectedRow.Cells["nombre_usuario"].Value.ToString();
                txtPassword.Text = selectedRow.Cells["pass"].Value.ToString();
            }
        }
    }
}

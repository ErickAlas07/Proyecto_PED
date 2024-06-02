using Avance_1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Avance_1.Data
{
    public class MatriculaDataAccess
    {
        private ConexionBD conexionBD;

        public MatriculaDataAccess()
        {
            conexionBD = new ConexionBD();
        }

        public List<Materia> TodasMaterias()
        {
            List<Materia> materias = new List<Materia>();

            try
            {
                using (MySqlConnection con = conexionBD.GetConexion())
                {
                    con.Open();

                    string query = "SELECT id_materia, nombre FROM materia";
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Materia materia = new Materia
                            {
                                Id = reader.GetInt32("id_materia"),
                                Nombre = reader.GetString("nombre")
                            };
                            materias.Add(materia);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al obtener todas las materias: {ex.Message}", ex);
            }

            return materias;
        }

        public bool EstaMatriculado(string idEstudiante, int idMateria)
        {
            try
            {
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();
                
                string query = "SELECT COUNT(*) FROM matricula WHERE id_estudiante = @IdEstudiante AND id_materia = @IdMateria";
                
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@IdEstudiante", idEstudiante);
                cmd.Parameters.AddWithValue("@IdMateria", idMateria);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                objCon.CerrarConexion();

                return count > 0;
                
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al verificar la matrícula: {ex.Message}", ex);
            }
        }

        public void InsertarMatricula(Matricula matricula)
        {
            // Confirmar si el usuario desea realmente inscribirse en la materia
            DialogResult result = MessageBox.Show("¿Está seguro de inscribirse en esta materia?", "Confirmar Matrícula", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.Yes)
            {
                try
                {
                    ConexionBD objCon = new ConexionBD();
                    MySqlConnection con = objCon.conexion;
                    con.Open();
                    string query = "INSERT INTO matricula (id_estudiante, id_materia, estado) VALUES (@IdEstudiante, @IdMateria, @Estado)";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@IdEstudiante", matricula.IdEstudiante);
                    cmd.Parameters.AddWithValue("@IdMateria", matricula.IdMateria);
                    cmd.Parameters.AddWithValue("@Estado", matricula.Estado);
                    cmd.ExecuteNonQuery();

                    objCon.CerrarConexion();

                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Error al insertar la matrícula: {ex.Message}", ex);
                }
            }
        }

        public DataTable ObtenerMatriculasEstudiante(string idEstudiante)
        {
            try
            {
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();
                string query = "SELECT m.id_materia, ma.nombre AS Materia, m.estado FROM matricula m JOIN materia ma ON m.id_materia = ma.id_materia WHERE m.id_estudiante = @IdEstudiante AND (m.estado = 'Pre-inscrito' OR m.estado = 'Inscrito')";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@IdEstudiante", idEstudiante);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                
                objCon.CerrarConexion();
                
                return table;
                
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al obtener las matrículas: {ex.Message}", ex);
            }
        }

        public void ActualizarEstadoMatricula(string idEstudiante, int idMateria, string nuevoEstado)
        {
            try
            {
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();
                
                string query = "UPDATE matricula SET estado = @NuevoEstado WHERE id_estudiante = @IdEstudiante AND id_materia = @IdMateria";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@NuevoEstado", nuevoEstado);
                cmd.Parameters.AddWithValue("@IdEstudiante", idEstudiante);
                cmd.Parameters.AddWithValue("@IdMateria", idMateria);
                cmd.ExecuteNonQuery();

                objCon.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al actualizar el estado de la matrícula: {ex.Message}", ex);
            }
        }

        public void EliminarMatricula(string idEstudiante, int idMateria)
        {
            try
            {
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();

                string query = "DELETE FROM matricula WHERE id_estudiante = @IdEstudiante AND id_materia = @IdMateria";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@IdEstudiante", idEstudiante);
                cmd.Parameters.AddWithValue("@IdMateria", idMateria);
                cmd.ExecuteNonQuery();

                objCon.CerrarConexion();

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al eliminar la matrícula: {ex.Message}", ex);
            }
        }
    }
}

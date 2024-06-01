using Avance_1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Avance_1.Data
{
    public class MateriaDataAccess
    {
        private ConexionBD mConexion;

        public MateriaDataAccess()
        {
            mConexion = new ConexionBD();
        }

        public DataTable ObtenerMaterias()
        {
            DataTable tabla = new DataTable();
            
            try
            {
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();

                string consulta = "SELECT * FROM materia";
                MySqlCommand comando = new MySqlCommand(consulta, con);
                
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                adaptador.Fill(tabla);
                
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cargar los datos: {ex.Message}", ex);
            }            
        return tabla;
        }

        public void AgregarMateria(Materia materia)
        {
            ConexionBD objCon = new ConexionBD();
            try
            {
                if (objCon.AbrirConexion())
                {
                    MySqlConnection con = objCon.conexion;
                    string query = "INSERT INTO materia (nombre, descripcion, aula, escuela, abreviatura, id_profesor) " +
                                "VALUES (@Nombre, @Descripcion, @Aula, @Escuela, @Abreviatura, @IdProfesor)";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Nombre", materia.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", materia.Descripcion);
                    cmd.Parameters.AddWithValue("@Aula", materia.Aula);
                    cmd.Parameters.AddWithValue("@Escuela", materia.Facultad);
                    cmd.Parameters.AddWithValue("@Abreviatura", materia.Abreviatura);
                    cmd.Parameters.AddWithValue("@IdProfesor", materia.IdProfesor);
                    cmd.ExecuteNonQuery();
                }
                objCon.CerrarConexion();
            }

            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al agregar la materia: {ex.Message}", ex);
            }
            
        }

        public void AcualizarMateria(Materia materia)
        {
            try
            {
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();

                string query = "UPDATE materia SET nombre = @Nombre, descripcion = @Descripcion, aula = @Aula, " +
                                "escuela = @Escuela, abreviatura = @Abreviatura, id_profesor = @IdProfesor WHERE id_materia = @Id";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", materia.Id);
                    cmd.Parameters.AddWithValue("@Nombre", materia.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", materia.Descripcion);
                    cmd.Parameters.AddWithValue("@Aula", materia.Aula);
                    cmd.Parameters.AddWithValue("@Escuela", materia.Facultad);
                    cmd.Parameters.AddWithValue("@Abreviatura", materia.Abreviatura);
                    cmd.Parameters.AddWithValue("@IdProfesor", materia.IdProfesor);
                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al actualizar la materia: {ex.Message}", ex);
            }
            
        }

        public void EliminarMateria(int id)
        {
            try
            {
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();

                //string query = "DELETE FROM materia WHERE id_materia = @Id";
                MySqlCommand query = new MySqlCommand("DELETE FROM materia WHERE id_materia = @Id", con);   
                query.Parameters.AddWithValue("@Id", id);
                query.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al eliminar la materia con ID {id}: {ex.Message}", ex);
            }

        }
    }
}


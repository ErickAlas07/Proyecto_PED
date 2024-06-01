using Avance_1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Avance_1.Data
{
    public class ProfesorDataAccess
    {
        private readonly ConexionBD conexionBD;
        private UsuarioDataAccess usuarioDataAccess;

        public ProfesorDataAccess()
        {
            conexionBD = new ConexionBD();
            usuarioDataAccess = new UsuarioDataAccess();
        }

        public DataTable TodosProfesores()
        {
            DataTable tabla = new DataTable();

            try
            {
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();

                string consulta = "SELECT p.id_profesor, CONCAT(p.nombre, ' ', p.apellido) AS Profesor, p.titulo, u.nombre_usuario AS Usuario FROM sistema.profesor p JOIN usuario u ON p.id_usuario = u.id_usuario";
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

        public List<Profesor> ObtenerProfesores()
        {
            try
            {
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();
                List<Profesor> profesores = new List<Profesor>();
                string query = "SELECT p.id_profesor, u.nombre_usuario, u.pass, u.id_rol, p.nombre, p.apellido, p.titulo FROM profesor p JOIN usuario u ON p.id_usuario = u.id_usuario";

                MySqlCommand comando = new MySqlCommand(query, con);
                MySqlDataReader reader = comando.ExecuteReader();    

                while (reader.Read())
                {   
                    Profesor profesor = new Profesor(
                        reader.GetString("nombre_usuario"),
                        reader.GetString("pass"),
                        reader.GetInt32("id_rol"),
                        reader.GetString("nombre"),
                        reader.GetString("apellido"),
                        reader.GetString("titulo")
                    );
                    profesor.Id = reader.GetInt32("id_profesor");
                    profesores.Add(profesor);
                }

                reader.Close();

                return profesores;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener los profesores: {ex.Message}");
            }  
        }

        public void InsertarProfesor(Profesor profesor)
        {
            try
            {
                if (UsuarioExiste(profesor.NombreUsuario))
                {
                    throw new InvalidOperationException("El nombre de usuario ya existe. Por favor, elija otro nombre de usuario.");
                }

                using (MySqlConnection conexion = conexionBD.GetConexion())
                {
                    conexion.Open();
                    using (MySqlTransaction transaction = conexion.BeginTransaction())
                    {
                        try
                        {
                            int userId = usuarioDataAccess.InsertarUsuario(profesor);

                            string teacherInsertQuery = "INSERT INTO profesor (nombre, apellido, titulo, id_usuario) VALUES (@FirstName, @LastName, @Title, @UserId)";
                            MySqlCommand teacherCmd = new MySqlCommand(teacherInsertQuery, conexion, transaction);
                            teacherCmd.Parameters.AddWithValue("@FirstName", profesor.Nombre);
                            teacherCmd.Parameters.AddWithValue("@LastName", profesor.Apellido);
                            teacherCmd.Parameters.AddWithValue("@Title", profesor.Titulo);
                            teacherCmd.Parameters.AddWithValue("@UserId", userId);
                            teacherCmd.ExecuteNonQuery();

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new InvalidOperationException($"Error al insertar el profesor: {ex.Message}", ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al conectar con la base de datos: {ex.Message}", ex);
            }
        }

        public void NuevoProfesor(Profesor profesor)
        {
            string nombreUsuario = GenerarNombreUsuario(profesor.Nombre, profesor.Apellido);
            string password = "1234";
            int idRol = 2; // Suponiendo que el ID 2 corresponde al rol de Profesor

            try
            {
                using (MySqlConnection conexion = conexionBD.GetConexion())
                {
                    conexion.Open();
                    using (MySqlTransaction transaction = conexion.BeginTransaction())
                    {
                        try
                        {
                            // Inserción en la tabla usuario
                            string userInsertQuery = "INSERT INTO usuario (nombre_usuario, pass, id_rol) VALUES (@UserName, @Password, @RoleId)";
                            MySqlCommand userCmd = new MySqlCommand(userInsertQuery, conexion, transaction);
                            userCmd.Parameters.AddWithValue("@UserName", nombreUsuario);
                            userCmd.Parameters.AddWithValue("@Password", password);
                            userCmd.Parameters.AddWithValue("@RoleId", idRol);
                            userCmd.ExecuteNonQuery();

                            int userId = (int)userCmd.LastInsertedId;

                            // Inserción en la tabla profesor
                            string teacherInsertQuery = "INSERT INTO profesor (nombre, apellido, titulo, id_usuario) VALUES (@FirstName, @LastName, @Title, @UserId)";
                            MySqlCommand teacherCmd = new MySqlCommand(teacherInsertQuery, conexion, transaction);
                            teacherCmd.Parameters.AddWithValue("@FirstName", profesor.Nombre);
                            teacherCmd.Parameters.AddWithValue("@LastName", profesor.Apellido);
                            teacherCmd.Parameters.AddWithValue("@Title", profesor.Titulo);
                            teacherCmd.Parameters.AddWithValue("@UserId", userId);
                            teacherCmd.ExecuteNonQuery();

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new InvalidOperationException($"Error al insertar el profesor: {ex.Message}", ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al conectar con la base de datos: {ex.Message}", ex);
            }
        }

        public void AcualizarProfesor(Profesor profesor)
        {
            try
            {
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();

                string query = "UPDATE profesor SET nombre = @Nombre, apellido = @Apellido WHERE id_profesor = @Id";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", profesor.Id);
                    cmd.Parameters.AddWithValue("@Nombre", profesor.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", profesor.Apellido);
                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al actualizar el profesor: {ex.Message}", ex);
            }

        }

        public void EliminarProfesor(int id)
        {
            try
            {
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();

                //string query = "DELETE FROM materia WHERE id_materia = @Id";
                MySqlCommand query = new MySqlCommand("DELETE FROM profesor WHERE id_profesor = @Id", con);
                query.Parameters.AddWithValue("@Id", id);
                query.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al eliminar el profesor con ID {id}: {ex.Message}", ex);
            }

        }

        public bool ExisteProfesor(string nombre, string apellido)
        {
            bool existe = false;

            try
            {
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();
                    
                string query = "SELECT COUNT(*) FROM profesor WHERE nombre = @Nombre AND apellido = @Apellido";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Apellido", apellido);

                existe = Convert.ToInt32(cmd.ExecuteScalar()) > 0;

                objCon.CerrarConexion();
                
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al verificar la existencia del profesor: {ex.Message}", ex);
            }

            return existe;
        }

        private string GenerarNombreUsuario(string nombre, string apellido)
        {
            string inicialNombre = nombre.Substring(0, 1).ToLower();
            string nombreUsuario = $"{inicialNombre}{apellido.ToLower()}";
            return nombreUsuario;
        }

        public bool UsuarioExiste(string nombreUsuario)
        {
            try
            {
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();

                string query = "SELECT COUNT(*) FROM usuario WHERE nombre_usuario = @UserName";
                //MySqlConnection conexion = conexionBD.GetConexion();

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserName", nombreUsuario);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;


            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al verificar la existencia del usuario: {ex.Message}", ex);
            }
        }
    }
}

using Avance_1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Avance_1.Data
{
    public class UsuarioDataAccess
    {
        private ConexionBD conexionBD;

        public UsuarioDataAccess()
        {
            conexionBD = new ConexionBD();
        }

        public int InsertarUsuario(Usuario usuario)
        {
            ConexionBD objCon = new ConexionBD();
            MySqlConnection con = objCon.conexion;
            con.Open();
            MySqlTransaction transaction = con.BeginTransaction();

            try
            {
                string userInsertQuery = "INSERT INTO usuario (nombre_usuario, pass, id_rol) VALUES (@Username, @Password, @RoleId); SELECT LAST_INSERT_ID();";
                MySqlCommand cmd = new MySqlCommand(userInsertQuery, con, transaction);
                cmd.Parameters.AddWithValue("@Username", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@Password", usuario.Password);
                cmd.Parameters.AddWithValue("@RoleId", usuario.IdRol);
                int userId = Convert.ToInt32(cmd.ExecuteScalar());
                transaction.Commit();

                objCon.CerrarConexion();
                return userId;

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException($"Error al insertar el usuario: {ex.Message}", ex);
            }
        }

        public bool UsuarioExiste(string nombreUsuario)
        {
            try
            {
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();
                
                string query = "SELECT COUNT(*) FROM usuario WHERE nombre_usuario = @Username";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", nombreUsuario);

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al verificar el usuario: {ex.Message}", ex);
            }
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            try
            {
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();
                string query = "UPDATE usuario SET nombre_usuario = @Username, pass = @Password WHERE id_usuario = @Id";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", usuario.Id);
                cmd.Parameters.AddWithValue("@Username", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@Password", usuario.Password);
                cmd.ExecuteNonQuery();

                objCon.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al actualizar el usuario: {ex.Message}", ex);
            }
        }

        public void EliminarUsuario(int id)
        {
            try
            {
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();

                string query = "DELETE FROM usuario WHERE id_usuario = @Id";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();

                objCon.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al eliminar el usuario: {ex.Message}", ex);
            }
        }

        public DataTable TodosUsuariosAdministradores()
        {
            try
            {
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();
                string query = "SELECT id_usuario, nombre_usuario, pass, id_rol FROM usuario WHERE id_rol = 1"; // Asumiendo que el rol de administrador es 1
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);

                objCon.CerrarConexion();
                return tabla;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al obtener los administradores: {ex.Message}", ex);
            }
        }
    }
}

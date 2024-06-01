using Avance_1.Models;
using MySql.Data.MySqlClient;
using System;

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
            try
            {
                using (MySqlConnection conexion = conexionBD.GetConexion())
                {
                    conexion.Open();
                    using (MySqlTransaction transaction = conexion.BeginTransaction())
                    {
                        try
                        {
                            string userInsertQuery = "INSERT INTO usuario (nombre_usuario, pass, id_rol) VALUES (@Username, @Password, @RoleId); SELECT LAST_INSERT_ID();";
                            MySqlCommand cmd = new MySqlCommand(userInsertQuery, conexion, transaction);
                            cmd.Parameters.AddWithValue("@Username", usuario.NombreUsuario);
                            cmd.Parameters.AddWithValue("@Password", usuario.Password);
                            cmd.Parameters.AddWithValue("@RoleId", usuario.IdRol);
                            int userId = Convert.ToInt32(cmd.ExecuteScalar());
                            transaction.Commit();
                            return userId;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new InvalidOperationException($"Error al insertar el usuario: {ex.Message}", ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al conectar con la base de datos: {ex.Message}", ex);
            }
        }

        public bool UsuarioExiste(string nombreUsuario)
        {
            try
            {
                using (MySqlConnection conexion = conexionBD.GetConexion())
                {
                    conexion.Open();
                    string query = "SELECT COUNT(*) FROM usuario WHERE nombre_usuario = @Username";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@Username", nombreUsuario);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al verificar el usuario: {ex.Message}", ex);
            }
        }
    }
}

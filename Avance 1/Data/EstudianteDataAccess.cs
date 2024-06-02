using MySql.Data.MySqlClient;
using System;
using Avance_1.Models;
using System.Data;

namespace Avance_1.Data
{
    public class EstudianteDataAccess
    {
        private ConexionBD conexionBD;
        private UsuarioDataAccess usuarioDataAccess;

        public EstudianteDataAccess()
        {
            conexionBD = new ConexionBD();
            usuarioDataAccess = new UsuarioDataAccess();
        }

        public DataTable TodosEstudiantes()
        {
            DataTable tabla = new DataTable();

            try
            {
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();

                string consulta = "SELECT e.id_estudiante AS Carnet, CONCAT(e.nombre, ' ', e.apellido) AS Estudiante, e.fecha_de_nacimiento, e.género, e.dirección, e.teléfono, e.correo_electrónico, u.nombre_usuario FROM sistema.estudiante e JOIN usuario u ON e.id_usuario = u.id_usuario";
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

        public void InsertarEstudiante(Estudiante estudiante)
        {
            try
            {
                if (UsuarioExiste(estudiante.NombreUsuario))
                {
                    throw new InvalidOperationException("El nombre de usuario ya existe. Por favor, elija otro nombre de usuario.");
                }

                if (CorreoElectronicoExiste(estudiante.CorreoElectronico))
                {
                    throw new InvalidOperationException("El correo electrónico ya existe. Por favor, utilice otro correo electrónico.");
                }
                
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();

                MySqlTransaction transaction = con.BeginTransaction();

                try
                {
                    int userId = usuarioDataAccess.InsertarUsuario(estudiante);

                    string studentInsertQuery = "INSERT INTO estudiante (id_estudiante, nombre, apellido, fecha_de_nacimiento, género, dirección, teléfono, correo_electrónico, id_usuario) " +
                                                "VALUES (@StudentId, @FirstName, @LastName, @BirthDate, @Gender, @Address, @Phone, @Email, @UserId)";
                    MySqlCommand studentCmd = new MySqlCommand(studentInsertQuery, con, transaction);
                    studentCmd.Parameters.AddWithValue("@StudentId", estudiante.IdEstudiante);
                    studentCmd.Parameters.AddWithValue("@FirstName", estudiante.Nombre);
                    studentCmd.Parameters.AddWithValue("@LastName", estudiante.Apellido);
                    studentCmd.Parameters.AddWithValue("@BirthDate", estudiante.FechaNacimiento);
                    studentCmd.Parameters.AddWithValue("@Gender", estudiante.Genero);
                    studentCmd.Parameters.AddWithValue("@Address", estudiante.Direccion);
                    studentCmd.Parameters.AddWithValue("@Phone", estudiante.Telefono);
                    studentCmd.Parameters.AddWithValue("@Email", estudiante.CorreoElectronico);
                    studentCmd.Parameters.AddWithValue("@UserId", userId);
                    studentCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new InvalidOperationException($"Error al insertar el estudiante: {ex.Message}", ex);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al conectar con la base de datos: {ex.Message}", ex);
            }
        }

        public void AcualizarEstudiante(Estudiante estudiante)
        {
            try
            {
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();

                string query = "UPDATE estudiante SET nombre = @Nombre, apellido = @Apellido, fecha_de_nacimiento = @Fecha, género = @Genero, dirección = @Direccion, teléfono = @Telefono, correo_electrónico = @Correo WHERE id_estudiante = @Id";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", estudiante.IdEstudiante);
                    cmd.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", estudiante.Apellido);
                    cmd.Parameters.AddWithValue("@Fecha", estudiante.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Genero", estudiante.Genero);
                    cmd.Parameters.AddWithValue("@Direccion", estudiante.Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", estudiante.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", estudiante.CorreoElectronico);
                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al actualizar el estudiante: {ex.Message}", ex);
            }

        }
        public void EliminarEstudiante(string id)
        {
            try
            {
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();

                MySqlCommand query = new MySqlCommand("DELETE FROM estudiante WHERE id_estudiante = @Id", con);
                query.Parameters.AddWithValue("@Id", id);
                query.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al eliminar el estudiante con Carnet {id}: {ex.Message}", ex);
            }

        }

        public void NuevoEstudiante(Estudiante estudiante)
        {
            // Validar si el Carnet ya existe
            if (ExisteEstudiante(estudiante.IdEstudiante))
            {
                throw new InvalidOperationException("El carnet del estudiante ya existe. Por favor, elija otro carnet.");
            }

            // Validar si el nombre de usuario ya existe
            if (UsuarioExiste(estudiante.NombreUsuario))
            {
                throw new InvalidOperationException("El nombre de usuario ya existe. Por favor, elija otro nombre de usuario.");
            }

            // Validar si el correo electrónico ya existe
            if (CorreoElectronicoExiste(estudiante.CorreoElectronico))
            {
                throw new InvalidOperationException("El correo electrónico ya existe. Por favor, utilice otro correo electrónico.");
            }

            string nombreUsuario = GenerarNombreUsuario(estudiante.Nombre, estudiante.Apellido);
            string password = "1234";
            int idRol = 3; // ID de rol estudiante

            try
            {
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();

                MySqlTransaction transaction = con.BeginTransaction();
                    
                try
                {
                    // Inserción en la tabla usuario
                    string userInsertQuery = "INSERT INTO usuario (nombre_usuario, pass, id_rol) VALUES (@UserName, @Password, @RoleId)";
                    MySqlCommand userCmd = new MySqlCommand(userInsertQuery, con, transaction);
                    userCmd.Parameters.AddWithValue("@UserName", nombreUsuario);
                    userCmd.Parameters.AddWithValue("@Password", password);
                    userCmd.Parameters.AddWithValue("@RoleId", idRol);
                    userCmd.ExecuteNonQuery();

                    int userId = (int)userCmd.LastInsertedId;

                    // Inserción en la tabla profesor
                    string query = "INSERT INTO estudiante (id_estudiante, nombre, apellido, fecha_de_nacimiento, género, dirección, teléfono, correo_electrónico, id_usuario) VALUES (@IdEstudiante, @Nombre, @Apellido, @Fecha, @Genero, @Direccion, @Telefono, @Email, @UserId)";
                    MySqlCommand teacherCmd = new MySqlCommand(query, con, transaction);
                    teacherCmd.Parameters.AddWithValue("@IdEstudiante", estudiante.IdEstudiante);
                    teacherCmd.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
                    teacherCmd.Parameters.AddWithValue("@Apellido", estudiante.Apellido);
                    teacherCmd.Parameters.AddWithValue("@Fecha", estudiante.FechaNacimiento);
                    teacherCmd.Parameters.AddWithValue("@Genero", estudiante.Genero);
                    teacherCmd.Parameters.AddWithValue("@Direccion", estudiante.Direccion);
                    teacherCmd.Parameters.AddWithValue("@Telefono", estudiante.Telefono);
                    teacherCmd.Parameters.AddWithValue("@Email", estudiante.CorreoElectronico);
                    teacherCmd.Parameters.AddWithValue("@UserId", userId);
                    teacherCmd.ExecuteNonQuery();

                    transaction.Commit();
                    con.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new InvalidOperationException($"Error al insertar el estudiante: {ex.Message}", ex);
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
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();

                string query = "SELECT COUNT(*) FROM usuario WHERE nombre_usuario = @UserName";
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

        public bool CorreoElectronicoExiste(string correoElectronico)
        {
            try
            {
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();
                string query = "SELECT COUNT(*) FROM estudiante WHERE correo_electrónico = @Email";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", correoElectronico);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;   
            }

            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al verificar la existencia del correo electrónico: {ex.Message}", ex);
            }
        }

        public bool ExisteEstudiante(string carnet)
        {
            bool existe;
            try
            {
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();

                string query = "SELECT COUNT(*) FROM estudiante WHERE id_estudiante = @Carnet";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Carnet", carnet);

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

        public string ObtenerIdEstudiantePorUsuario(int idUsuario)
        {
            try
            {
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();

                string query = "SELECT id_estudiante FROM estudiante WHERE id_usuario = @IdUsuario";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                var result = cmd.ExecuteScalar();
                //objCon.CerrarConexion();
                if (result != null)
                {
                    return result.ToString(); // Convertir el resultado a string
                }
                else
                {
                    return ""; // Retornar cadena vacía si no se encuentra el estudiante
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al obtener el ID del estudiante: {ex.Message}", ex);
            }
        }

    }
}

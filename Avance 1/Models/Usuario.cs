using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avance_1.Models
{
    public class Usuario
    {
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public int IdRol { get; set; }

        public Usuario(string nombreUsuario, string password, int idRol)
        {
            NombreUsuario = nombreUsuario;
            Password = password;
            IdRol = idRol;
        }

        public virtual bool Validate(out string errorMessage)
        {
            errorMessage = "";
            if (string.IsNullOrWhiteSpace(NombreUsuario))
            {
                errorMessage += "- Nombre de Usuario\n";
            }
            if (string.IsNullOrWhiteSpace(Password))
            {
                errorMessage += "- Contraseña\n";
            }

            return string.IsNullOrEmpty(errorMessage);
        }
    }
}

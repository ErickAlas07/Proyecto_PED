using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avance_1.Models
{
    public class Profesor : Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Titulo { get; set; }

        public string NombreCompleto => $"{Nombre} {Apellido}";

        public Profesor(string nombreUsuario, string password, int idRol, string nombre, string apellido, string titulo)
            : base(nombreUsuario, password, idRol)
        {
            Nombre = nombre;
            Apellido = apellido;
            Titulo = titulo;
        }

        public override bool Validate(out string errorMessage)
        {
            bool baseValid = base.Validate(out errorMessage);
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                errorMessage += "- Nombre\n";
            }
            if (string.IsNullOrWhiteSpace(Apellido))
            {
                errorMessage += "- Apellido\n";
            }
            if (string.IsNullOrWhiteSpace(Titulo))
            {
                errorMessage += "- Título\n";
            }

            return baseValid && string.IsNullOrEmpty(errorMessage);
        }

        public override string ToString()
        {
            return NombreCompleto;
        }
    }
}

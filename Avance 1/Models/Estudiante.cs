using System;

namespace Avance_1.Models
{
    public class Estudiante : Usuario
    {
        public string IdEstudiante { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }

        public Estudiante(string nombreUsuario, string password, int idRol, string idEstudiante, string nombre, string apellido, DateTime fechaNacimiento, string genero, string direccion, string telefono, string correoElectronico)
            : base(nombreUsuario, password, idRol)
        {
            IdEstudiante = idEstudiante;
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
            Genero = genero;
            Direccion = direccion;
            Telefono = telefono;
            CorreoElectronico = correoElectronico;
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
            if (string.IsNullOrWhiteSpace(Direccion))
            {
                errorMessage += "- Dirección\n";
            }
            if (string.IsNullOrWhiteSpace(Telefono))
            {
                errorMessage += "- Teléfono\n";
            }
            if (string.IsNullOrWhiteSpace(CorreoElectronico))
            {
                errorMessage += "- Correo Electrónico\n";
            }
            if (string.IsNullOrWhiteSpace(Genero))
            {
                errorMessage += "- Género\n";
            }

            return baseValid && string.IsNullOrEmpty(errorMessage);
        }
    }
}

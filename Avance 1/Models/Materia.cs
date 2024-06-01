using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avance_1.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Aula { get; set; }
        public string Facultad { get; set; }
        public string Abreviatura { get; set; }
        public int IdProfesor { get; set; }
    }
}

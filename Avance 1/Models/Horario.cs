using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avance_1.Models
{
    public class Horario
    {
        public int IdHorario { get; set; }
        public int IdMateria { get; set; }
        public string DiaDeLaSemana { get; set; }
        public TimeSpan HoraInicial { get; set; }
        public TimeSpan HoraFinal { get; set; }
    }

}

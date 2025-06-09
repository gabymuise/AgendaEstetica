using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEstetica.Model
{
    public class HorarioCita
    {
        public int IdHorarios { get; set; }
        public string Dia { get; set; } // ej: "Lunes", "Martes"
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public bool Disponible { get; set; }

        public int IdEmpleado { get; set; }
        public Empleado Empleado { get; set; }

        // Relación con tabla puente
        public List<AgendaCitaHorarioCita> AgendaCitaHorarios { get; set; }
    }
}

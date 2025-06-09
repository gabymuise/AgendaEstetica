using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEstetica.Model
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public string Telefono { get; set; }

        // Relación: Un empleado tiene muchos horarios
        public List<HorarioCita> Horarios { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEstetica.Model
{
    public class HorarioCita
    {
        public int Idhorarios { get; set; }
        public string? Dia { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? Hora { get; set; }
        public int IdEmpleado { get; set; }
        public bool Disponible { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Empleados? Empleado { get; set; }
        public ICollection<AgendaCitaHorario>? AgendaCitaHorarios { get; set; }
    }
}

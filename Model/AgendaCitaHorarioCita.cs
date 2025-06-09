using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEstetica.Model
{
    public class AgendaCitaHorarioCita
    {
        public int IdHorarioCitas { get; set; }
        public HorarioCita HorarioCita { get; set; }

        public int IdAgendaCitas { get; set; }
        public AgendaCita AgendaCita { get; set; }
    }
}

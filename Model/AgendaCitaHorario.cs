using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEstetica.Model
{
    public class AgendaCitaHorario
    {
        public int IdHorarioCitas { get; set; }
        public int IdAgendaCitas { get; set; }
        public DateTime? CreatedAt { get; set; }

        public HorarioCita? HorarioCita { get; set; }
        public AgendaCitas? AgendaCita { get; set; }
    }
}

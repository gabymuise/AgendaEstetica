using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEstetica.Model
{
    public class AgendaCita
    {
        public int IdAgendaCitas { get; set; }
        public decimal PrecioFinal { get; set; }
        public bool Pagado { get; set; }
        public bool Finalizado { get; set; }

        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }

        public int IdServicios { get; set; }
        public Servicio Servicio { get; set; }

        // Relación con tabla puente
        public List<AgendaCitaHorarioCita> HorariosCitas { get; set; }
    }
}

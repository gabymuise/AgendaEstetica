using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEstetica.Model
{
    public class AgendaCitas
    {
        public int IdAgendaCitas { get; set; }
        public decimal PrecioFinal { get; set; }
        public bool Pagado { get; set; }
        public bool Finalizado { get; set; }
        public int IdCliente { get; set; }
        public int IdServicios { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Clientes? Cliente { get; set; }
        public Servicios? Servicio { get; set; }
        public ICollection<AgendaCitaHorario>? AgendaCitaHorarios { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEstetica.Model
{
    public class Servicios
    {
        public int IdServicios { get; set; }
        public string Nombre { get; set; }
        public int DuracionEstimada { get; set; } // en minutos
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public ICollection<AgendaCitas>? AgendaCitas { get; set; }
    }
}

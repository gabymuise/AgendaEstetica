using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEstetica.Model
{
    public class Servicio
    {
        public int IdServicios { get; set; }
        public string Nombre { get; set; }
        public int DuracionEstimada { get; set; } // en minutos
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }

        // Relación: un servicio puede estar en varias citas
        public List<AgendaCita> Citas { get; set; }
    }
}

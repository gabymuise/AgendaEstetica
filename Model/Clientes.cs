using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEstetica.Model
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string NombreApellido { get; set; }
        public string Telefono { get; set; }

        // Relación: Un cliente tiene muchas citas
        public List<AgendaCita> Citas { get; set; }
    }
}

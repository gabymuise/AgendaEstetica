using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEstetica.Model
{
    public class Clientes
    {
        public int IdCliente { get; set; }
        public string? NombreApellido { get; set; }
        public string? Telefono { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public ICollection<AgendaCitas>? AgendaCitas { get; set; }
    }
}

using AgendaEstetica.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;

namespace AgendaEstetica
{
    internal static class Program
    {
        // Hacemos que el contexto esté disponible globalmente
        public static AgendaEsteticaContext DbContext;

        [STAThread]
        static void Main()
        {
            // Configuramos EF Core para SQL Server
            var optionsBuilder = new DbContextOptionsBuilder<AgendaEsteticaContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=agendaEstetica;Trusted_Connection=True;");
            DbContext = new AgendaEsteticaContext(optionsBuilder.Options);

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}

using AgendaEstetica.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaEstetica.Model.Dao
{
    public class AgendaCitasDao
    {
        private readonly AgendaEsteticaContext _context;

        public AgendaCitasDao()
        {
            _context = new AgendaEsteticaContext();
        }

        public void Agregar(AgendaCitas cita)
        {
            cita.CreatedAt = DateTime.Now;
            _context.AgendaCitas.Add(cita);
            _context.SaveChanges();
        }

        public AgendaCitas ObtenerPorId(int id)
        {
            return _context.AgendaCitas
                .Include(a => a.Cliente)
                .Include(a => a.Servicio)
                .FirstOrDefault(a => a.IdAgendaCitas == id && a.DeletedAt == null);
        }

        public List<AgendaCitas> ListarCitasActivas()
        {
            return _context.AgendaCitas
                .Where(a => a.DeletedAt == null)
                .Include(a => a.Cliente)
                .Include(a => a.Servicio)
                .OrderBy(a => a.CreatedAt)
                .ToList();
        }

        public void Actualizar(AgendaCitas citaActualizada)
        {
            var cita = _context.AgendaCitas.FirstOrDefault(a => a.IdAgendaCitas == citaActualizada.IdAgendaCitas && a.DeletedAt == null);
            if (cita != null)
            {
                cita.PrecioFinal = citaActualizada.PrecioFinal;
                cita.Pagado = citaActualizada.Pagado;
                cita.Finalizado = citaActualizada.Finalizado;
                cita.IdCliente = citaActualizada.IdCliente;
                cita.IdServicios = citaActualizada.IdServicios;
                cita.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            var cita = _context.AgendaCitas.FirstOrDefault(a => a.IdAgendaCitas == id && a.DeletedAt == null);
            if (cita != null)
            {
                cita.DeletedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public List<AgendaCitas> ListarCitasPorCliente(int idCliente)
        {
            return _context.AgendaCitas
                .Where(a => a.IdCliente == idCliente && a.DeletedAt == null)
                .Include(a => a.Servicio)
                .ToList();
        }

        public List<AgendaCitas> ListarCitasPendientesPago()
        {
            return _context.AgendaCitas
                .Where(a => !a.Pagado && a.DeletedAt == null)
                .Include(a => a.Cliente)
                .ToList();
        }
    }
}
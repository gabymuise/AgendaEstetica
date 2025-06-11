using AgendaEstetica.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaEstetica.Model.Dao
{
    public class HorarioCitaDao
    {
        private readonly AgendaEsteticaContext _context;

        public HorarioCitaDao()
        {
            _context = new AgendaEsteticaContext();
        }

        public void Agregar(HorarioCita horario)
        {
            horario.CreatedAt = DateTime.Now;
            _context.HorarioCita.Add(horario);
            _context.SaveChanges();
        }

        public HorarioCita ObtenerPorId(int id)
        {
            return _context.HorarioCita.FirstOrDefault(h => h.Idhorarios == id && h.DeletedAt == null);
        }

        public List<HorarioCita> ListarHorariosActivos()
        {
            return _context.HorarioCita
                .Where(h => h.DeletedAt == null)
                .OrderBy(h => h.Fecha)
                .ThenBy(h => h.Hora)
                .ToList();
        }

        public void Actualizar(HorarioCita horarioActualizado)
        {
            var horario = _context.HorarioCita.FirstOrDefault(h => h.Idhorarios == horarioActualizado.Idhorarios && h.DeletedAt == null);
            if (horario != null)
            {
                horario.Dia = horarioActualizado.Dia;
                horario.Fecha = horarioActualizado.Fecha;
                horario.Hora = horarioActualizado.Hora;
                horario.IdEmpleado = horarioActualizado.IdEmpleado;
                horario.Disponible = horarioActualizado.Disponible;
                horario.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            var horario = _context.HorarioCita.FirstOrDefault(h => h.Idhorarios == id && h.DeletedAt == null);
            if (horario != null)
            {
                horario.DeletedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public List<HorarioCita> ListarHorariosDisponibles()
        {
            return _context.HorarioCita
                .Where(h => h.Disponible && h.DeletedAt == null)
                .ToList();
        }

        public List<HorarioCita> ListarHorariosPorEmpleado(int idEmpleado)
        {
            return _context.HorarioCita
                .Where(h => h.IdEmpleado == idEmpleado && h.DeletedAt == null)
                .ToList();
        }
    }
}
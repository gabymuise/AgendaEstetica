using AgendaEstetica.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaEstetica.Model.Dao
{
    public class EmpleadosDao
    {
        private readonly AgendaEsteticaContext _context;

        public EmpleadosDao()
        {
            _context = new AgendaEsteticaContext();
        }

        public void Agregar(Empleados empleado)
        {
            empleado.CreatedAt = DateTime.Now;
            _context.Empleados.Add(empleado);
            _context.SaveChanges();
        }

        public Empleados ObtenerPorId(int id)
        {
            return _context.Empleados.FirstOrDefault(e => e.IdEmpleado == id && e.DeletedAt == null);
        }

        public List<Empleados> ListarEmpleadosActivos()
        {
            return _context.Empleados
                .Where(e => e.DeletedAt == null)
                .OrderBy(e => e.Nombre)
                .ToList();
        }

        public void Actualizar(Empleados empleadoActualizado)
        {
            var empleado = _context.Empleados.FirstOrDefault(e => e.IdEmpleado == empleadoActualizado.IdEmpleado && e.DeletedAt == null);
            if (empleado != null)
            {
                empleado.Nombre = empleadoActualizado.Nombre;
                empleado.Especialidad = empleadoActualizado.Especialidad;
                empleado.Telefono = empleadoActualizado.Telefono;
                empleado.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            var empleado = _context.Empleados.FirstOrDefault(e => e.IdEmpleado == id && e.DeletedAt == null);
            if (empleado != null)
            {
                empleado.DeletedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public List<Empleados> BuscarPorEspecialidad(string especialidad)
        {
            return _context.Empleados
                .Where(e => e.Especialidad.Contains(especialidad) && e.DeletedAt == null)
                .ToList();
        }
    }
}
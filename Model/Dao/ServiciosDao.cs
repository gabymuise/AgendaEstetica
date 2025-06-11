using AgendaEstetica.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaEstetica.Model.Dao
{
    public class ServiciosDao
    {
        private readonly AgendaEsteticaContext _context;

        public ServiciosDao()
        {
            _context = new AgendaEsteticaContext();
        }

        public void Agregar(Servicios servicio)
        {
            servicio.CreatedAt = DateTime.Now;
            _context.Servicios.Add(servicio);
            _context.SaveChanges();
        }

        public Servicios ObtenerPorId(int id)
        {
            return _context.Servicios.FirstOrDefault(s => s.IdServicios == id && s.DeletedAt == null);
        }

        public List<Servicios> ListarServiciosActivos()
        {
            return _context.Servicios
                .Where(s => s.DeletedAt == null)
                .OrderBy(s => s.Nombre)
                .ToList();
        }

        public void Actualizar(Servicios servicioActualizado)
        {
            var servicio = _context.Servicios.FirstOrDefault(s => s.IdServicios == servicioActualizado.IdServicios && s.DeletedAt == null);
            if (servicio != null)
            {
                servicio.Nombre = servicioActualizado.Nombre;
                servicio.DuracionEstimada = servicioActualizado.DuracionEstimada;
                servicio.Precio = servicioActualizado.Precio;
                servicio.Descripcion = servicioActualizado.Descripcion;
                servicio.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            var servicio = _context.Servicios.FirstOrDefault(s => s.IdServicios == id && s.DeletedAt == null);
            if (servicio != null)
            {
                servicio.DeletedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public List<Servicios> BuscarPorNombre(string nombre)
        {
            return _context.Servicios
                .Where(s => s.Nombre.Contains(nombre) && s.DeletedAt == null)
                .ToList();
        }
    }
}